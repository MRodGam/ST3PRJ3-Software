using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer // Consumer
{
    public class DataTreatment : Observer, IDataTreatment
    {
        private ConvertAlgo ConvertAlgorithm;
        private UC7S3_Filter FilterController;
        private UC1M1_ZeroAdjustment AdjustmentController;
        private Observer observer;
        private IData DataInterface;

        private BlockingCollection<RawData> _collection;
        private static Thread DataCollectorThread;
        private static Thread GraphThread;

        public static List<RawData> FullList;
        public static List<RawData> DownsampledRawList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;

        public static double CaliValue { get; private set; }
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double ZeroAdjustedAverage { get; set; }
        private static int Time { get; set; } = 1;
        public static int Counter { get; set; } = 0;
        public double calibrationVal { get; private set; }



        public DataTreatment(BlockingCollection<RawData> collection, Observer obs, IData iData )
        {
            DataInterface = iData;
            _collection = collection;
            observer = obs;

            FullList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            DownsampledRawList = new List<RawData>();
            GraphList = new List<ConvertedData>();

            DataCollectorThread = new Thread(MakeShortRawList);
        }

        public void StartGraphData()
        {
            ShallStop = false;
            DataCollectorThread.Start();
        }

        public void StopGraphData()
        {
            ShallStop = true;
        }
        public void Done()
        {
            Notify();
        }

        //public void GetRawData()
        //{
        //     while (!ShallStop)
        //     {
        //         for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
        //         {
        //             FullList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
        //         }
        //     }
        //}

        //void IDataTreatment.MakeShortRawList()
        //{
        //    MakeShortRawList();
        //}

        //public static void MakeShortRawList() // Giver fejl fordi den er static
        //{
        //    CaliValue = DataInterface.GetCalibrateValue();

        //    while (!ShallStop)
        //    {
        //        if (DownsampledRawList.Count < 300)
        //        {
        //            isListFull = false;

        //            if (FullList.Count < 5016) // If the list is shorter than the 5 sec window in the graph
        //            {
        //                for (int i = 1; i < 5016; i += 17)
        //                {
        //                    Total = 0;
        //                    for (int u = -8; u <= 8; u++) // Downsampling 17, 8 + 1 + 8.
        //                    {
        //                        Total += FullList[i + u].Voltage;
        //                    }

        //                    double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
        //                    Average = (Total / 17) - zeroValue;
        //                    DownsampledRawList.Add(new RawData(Time, Average));

        //                    foreach (var sample in DownsampledRawList)
        //                    {
        //                        Time++;
        //                        GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(sample.Second, sample.Voltage, CaliValue))); ;
        //                    }
        //                }
        //            }
        //            if (FullList.Count >= 5016) // If the list is longer than the 5 sec window in the graph
        //            {
        //                for (int i = FullList.Count - 5016; i < FullList.Count; i += 17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
        //                {
        //                    Total = 0;
        //                    for (int u = -8; u <= 8; u++) // Downsampling 17, 8 + 1 + 8.
        //                    {
        //                        Total += FullList[i + u].Voltage;
        //                    }

        //                    double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
        //                    Average = (Total / 17) - zeroValue;
        //                    DownsampledRawList.Add(new RawData(Time, Average));

        //                    foreach (var sample in DownsampledRawList)
        //                    {
        //                        Time++;
        //                        GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(sample.Second, sample.Voltage, CaliValue))); ;
        //                    }
        //                }
        //            }
        //        }

        //        if (DownsampledRawList.Count == 300) // 300 samples equals 5 sec on 60Hz
        //        {
        //            Done(); // ??????

        //            for (int i = 0; i < 60; i++) // 60 samples is 1 sec on 60Hz
        //            {
        //                DownsampledRawList.RemoveAt(i);
        //            }
        //        }

        //        Thread.Sleep(500); // Evt variér de 500
        //    }
        //}
        public void MakeShortRawList() // Lav en observer som fortæller når den er fuld
        {

            // calibrationVal = Database.GetCalibrateValue();

            while (!ShallStop)
            {
                for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                {
                    FullList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                }

                if (FullList.Count == 2000) // Downsampling starter først, når der er 5 sekunders data
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Time = ((1 / 60) * i) + 10;
                        GraphList.Add(new ConvertedData(Time, 1));
                    }

                    Done();
                }


                else if (FullList.Count > 2000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count; i += 17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
                    {
                        Total = 0;
                        ZeroAdjustedAverage = 0;
                        for (int u = -8; u <= 8; u++) // Downsampling 17, 8 + 1 + 8.
                        {
                            int placement = FullList.Count - 1000 + u;
                            Total += FullList[placement].Voltage;
                        }

                        //double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
                        // Average = (Total / 17) - zeroValue;
                        ZeroAdjustedAverage = AdjustmentController.ZeroAdjust((Total / 17));
                        Time += (1 / 60) * 17;

                        DownsampledRawList.Add(new RawData(Time, ZeroAdjustedAverage));

                        if (DownsampledRawList.Count == 120)
                        {
                            Done();
                        }

                        if (DownsampledRawList.Count < 300)
                        {
                            foreach (var sample in DownsampledRawList)
                            {
                                GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(sample.Second, sample.Voltage, calibrationVal))); ;
                            }


                        }
                        else if (DownsampledRawList.Count == 300)
                        {
                            for (int y = 0; y < 60; y++) // 60 samples is 1 sec on 60Hz
                            {
                                DownsampledRawList.RemoveAt(y);
                                GraphList.RemoveAt(y);
                            }
                        }
                    }
                    // Thread.Sleep(500); // Evt variér de 500
                }
            }

        }


        public List<ConvertedData> GetGraphList() // Skal returnere det nedsamplede converterede data fratrukket nulpunktsjusteringen
        {
           return GraphList;
        }

        public List<RawData> GetFilterList() // Skal returnere det nedsamplede rådata fratrukket nulpunktsjusteringen
        {
            return DownsampledRawList;
        }

        public void StartFilter()
        {
            throw new NotImplementedException();
        }

        public void StopFilter()
        {
            throw new NotImplementedException();
        }

        public void FilterData()
        {
            throw new NotImplementedException();
        }

        public List<RawData> GetFilterData()
        {
            throw new NotImplementedException();
        }
    }
}
