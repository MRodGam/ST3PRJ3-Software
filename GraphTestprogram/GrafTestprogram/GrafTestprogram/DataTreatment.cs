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
    public class DataTreatment : Subject, IDataTreatment
    {
        private static ConvertAlgo ConvertAlgorithm;
        // private UC7S3_Filter FilterController;
        // private UC1M1_ZeroAdjustment AdjustmentController;
        private Subject observer;
        //private Database Database;

        private BlockingCollection<RawData> _collection;
        private static Thread DataCollectorThread;
        // private static Thread GraphThread;

        public static List<RawData> FullList;
        public static List<RawData> DownsampledRawList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;
      
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double Average { get; set; }
        private static int Time { get; set; } = 0;
        public static bool isListFull { get; private set; } = false;
        public static int Counter { get; set; } = 0;
        public double calibrationVal { get; private set; }


        public DataTreatment(BlockingCollection<RawData> collection, ConvertAlgo conv) //Database data
        {
            _collection = collection;
            ConvertAlgorithm = conv;
            // Database = data;

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

        public void GetRawData()
        {

        }

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


                else if(FullList.Count >2000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count; i += 17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
                    {
                        Total = 0;
                        Average = 0;
                        for (int u = -8; u <= 8; u++) // Downsampling 17, 8 + 1 + 8.
                        {
                            int placement = FullList.Count - 1000 + u;
                            Total += FullList[placement].Voltage;
                        }

                        //double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
                        // Average = (Total / 17) - zeroValue;
                        Average = (Total / 17);
                        Time += (1 / 60) * 17;

                        DownsampledRawList.Add(new RawData(Time, Average));

                        if (DownsampledRawList.Count == 120)
                        {
                            Done();
                        }

                        if (DownsampledRawList.Count < 300)
                        {
                            foreach (var sample in DownsampledRawList)
                            {
                                GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(sample.Second, sample.Voltage,calibrationVal))); ;
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
                    
                    }
                    // Thread.Sleep(500); // Evt variér de 500
                }
            }

        public List<ConvertedData> GetGraphList() 
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
