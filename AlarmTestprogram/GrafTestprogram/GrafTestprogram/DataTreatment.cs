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
        //private IDatabase Database;

        private static object myLock = new object();

        private BlockingCollection<RawData> _collection;
        private static Thread DataCollectorThread;

        private static Thread GraphThread;

        public static List<RawData> FullList;
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

        private static List<ConvertedData> graphList;
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double Average { get; set; }
        private static double Time { get; set; } = 0;
        public static bool isListFull { get; private set; } = false;
        public static int Counter { get; set; } = 0;
        public double calibrationVal { get; private set; }
        public double[] DownsampledTimeArray = new double[300];
        public double[] DownsampledPressureArray = new double[300];


        public DataTreatment(BlockingCollection<RawData> collection, ConvertAlgo conv) //Database data
        {
            _collection = collection;
            ConvertAlgorithm = conv;
            // Database = data;

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

            //calibrationVal = Database.GetCalibrateValue();
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
            while (!ShallStop)
            {
                for (int i = 0; i < 100; i++)
                {
                    FullList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                }

                if (FullList.Count > 2000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count; i += 17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
                    {
                        Total = 0;
                        Average = 0;

                        Total = FullList[i - 8].Voltage + FullList[i - 7].Voltage + FullList[i - 6].Voltage + FullList[i - 5].Voltage + FullList[i - 4].Voltage + FullList[i - 3].Voltage + FullList[i - 2].Voltage + FullList[i - 1].Voltage + FullList[i].Voltage + FullList[i +1].Voltage + FullList[i + 2].Voltage + FullList[i + 3].Voltage + FullList[i + 4].Voltage + FullList[i + 5].Voltage + FullList[i + 6].Voltage + FullList[i + 7].Voltage + FullList[i + 8].Voltage;

                        //double zeroValue = AdjustmentController.GetZeroAdjustmentValue(); // Or whatever
                        // Average = (Total / 17) - zeroValue;
                        Average = (Total / 17);
                        Time += (1 / 60) * 17;


                        DownsampledRawList.Add(new RawData(Time, Average));

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

                Thread.Sleep(20); // Evt variér de 500
                                 // Fortæl at den er færdig
                                 // Vent 
            }
        
        } 

        public void MakeGraphList()
        {
            while(!ShallStop)
            {
                Thread.Sleep(20);

                //if (FullList.Count == 2000) // Downsampling starter først, når der er 5 sekunders data
                //{
                //    for (int i = 0; i < 60; i++)
                //    {
                //        Time = (1 / 60) * i;
                //        GraphList.Add(new ConvertedData(Time, 0));
                //    }

                //    Done();
                //}

                //foreach (var sample in DownsampledRawList)
                //if (DownsampledRawList.Count < 60)
                //{
                //    GraphList.Add(new ConvertedData(Time, 1));
                //}

                //if (60 <= DownsampledRawList.Count && DownsampledRawList.Count <= 300)
                //{
                //    Done();

                //    for (int i = DownsampledRawList.Count - 100; i < DownsampledRawList.Count; i++)
                //    {
                //        GraphList.Add(new ConvertedData(Time, ConvertAlgorithm.ConvertData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage)));
                //    }
                //}
                //else if (DownsampledRawList.Count >300)
                //{
                //    for (int i = DownsampledRawList.Count - 300; i < DownsampledRawList.Count; i++)
                //    {
                //        DownsampledRawList.RemoveAt(i);
                //    }
                //}

                // if (60 < DownsampledRawList.Count && DownsampledRawList.Count < 300)
                if (60 <= DownsampledRawList.Count)
                {
                    for (int i = DownsampledRawList.Count - 60; i < DownsampledRawList.Count; i++)
                    {
                        //GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, ConvertAlgorithm.ConvertData(DownsampledRawList[i].Voltage)));
                        GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage));
                    }

                    Done();
                }

                //if (DownsampledPressureArray.Length < 300 && DownsampledTimeArray.Length < 300)
                //{
                //    for (int i = 0; i < DownsampledTimeArray.Length; i++)
                //    {
                //        DownsampledTimeArray[i] = DownsampledRawList[i].Second;
                //        DownsampledPressureArray[i]= DownsampledRawList[i].Voltage;
                //    }
                //    foreach (var sample in DownsampledRawList)
                //    {
                //        int amount++;
                //        DownsampledTimeArray[amount] = sample.Second;
                //        DownsampledPressureArra sample.Voltage;
                //    }
                //}
                //if (DownsampledTimeArray.Length > 300 && DownsampledTimeArray.Length > 300)
                //{
                //    for (int i = 0; i < 60; i++)
                //    {
                //        DownsampledTimeArray[i].
                //        DownsampledPressureArray = sample.Voltage;
                //    }
                //}

                //Fortælle at den er færdig
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
