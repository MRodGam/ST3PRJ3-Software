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
    public class DataTreatment : Subject//, IDataTreatment
    {
        private ConvertAlgo ConvertAlgorithm;
        private UC7S3_Filter FilterController;
        private UC1M1_ZeroAdjustment AdjustmentController;
        private Subject observer;
        private IData DataInterface;
        private CalibrationValue CaliValue;

        private static object myLock = new object();
        private BlockingCollection<RawData> _collection;
        private static Thread DataCollectorThread;
        private static Thread GraphThread;

        public List<RawData> FullList { get; private set; } // har fjernet static da man ellers ikke kan kalde den fra UC_savedata
        public static List<RawData> DownsampledRawList;
        public static List<ConvertedData> ConvertedDataList;

        public static List<ConvertedData> GraphList
        {
            get
            {
                lock (myLock)
                {
                    return graphList;
                }
            }

            private set
            {
                lock (myLock)
                {
                    graphList = value;
                }
            }
        }

        private static List<ConvertedData> graphList; // bliver denne brugt?


        //public static double CaliValue { get; set; } // mangles at blive sat et sted!
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double ZeroAdjustedAverage { get; set; }
        private static int Time { get; set; } = 1;
        public static int Counter { get; set; } = 0;
        //public double calibrationVal { get; private set; }

        

        public DataTreatment(BlockingCollection<RawData> collection, Subject obs, IData iData, ConvertAlgo conv, CalibrationValue caliValue)
        {
            DataInterface = iData;
            _collection = collection;
            observer = obs;
            ConvertAlgorithm = conv;
            CaliValue = caliValue;

            FullList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            DownsampledRawList = new List<RawData>();
            GraphList = new List<ConvertedData>();
           
        }

        public void StartGraphData()
        {
            ShallStop = false;
            DataCollectorThread = new Thread(MakeShortRawList);
            GraphThread = new Thread(MakeGraphList);

            DataCollectorThread.Start();
            GraphThread.Start();
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

                if (FullList.Count > 2000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count; i += 17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
                    {
                        Total = 0;
                        ZeroAdjustedAverage = 0;

                        Total = FullList[i - 8].Voltage + FullList[i - 7].Voltage + FullList[i - 6].Voltage + FullList[i - 5].Voltage + FullList[i - 4].Voltage + FullList[i - 3].Voltage + FullList[i - 2].Voltage + FullList[i - 1].Voltage + FullList[i].Voltage + FullList[i + 1].Voltage + FullList[i + 2].Voltage + FullList[i + 3].Voltage + FullList[i + 4].Voltage + FullList[i + 5].Voltage + FullList[i + 6].Voltage + FullList[i + 7].Voltage + FullList[i + 8].Voltage;

                        //double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
                        // Average = (Total / 17) - zeroValue;
                        ZeroAdjustedAverage = (Total / 17);
                        Time += (1 / 60) * 17;


                        DownsampledRawList.Add(new RawData(Time, ZeroAdjustedAverage));

                        //if (DownsampledRawList.Count == 120)
                        //{
                        //    Done();
                        //}

                        //if (DownsampledRawList.Count < 300)
                        //{
                        //    //foreach (var sample in DownsampledRawList)
                        //    //{
                        //    //    GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(sample.Second, sample.Voltage, calibrationVal))); ;
                        //    //}


                        //}
                        //else if (DownsampledRawList.Count == 300)
                        //{
                        //    for (int y = 0; y < 60; y++) // 60 samples is 1 sec on 60Hz
                        //    {
                        //        DownsampledRawList.RemoveAt(y);
                        //        GraphList.RemoveAt(y);
                        //    }
                        //}
                    }
                } 
            }
        }

        public void MakeGraphList(/*List<RawData> liste*/) // konverterer data 
        {
            while (!ShallStop)
            {
                Thread.Sleep(20);
                
                // if (60 < DownsampledRawList.Count && DownsampledRawList.Count < 300)
                if (60 <= DownsampledRawList/*liste*/.Count)
                {
                    for (int i = DownsampledRawList.Count - 60; i < DownsampledRawList.Count; i++)
                    {
                        GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, ConvertAlgorithm.ConvertData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage, CaliValue.Value)));
                        //GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage));
                    }

                    Done();
                }
            }
        }



        public List<ConvertedData> GetGraphList() // Skal returnere det nedsamplede converterede data fratrukket nulpunktsjusteringen
        {
           return GraphList;
        }

        public List<RawData> GetDownsampledList() // Skal returnere det nedsamplede rådata fratrukket nulpunktsjusteringen
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
