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
using NationalInstruments.Restricted;

namespace LogicLayer // Consumer
{
    public class DataTreatment : Subject //, IDataTreatment
    {
        private static ConvertAlgo ConvertAlgorithm;
        // private UC7S3_Filter FilterController;
        // private UC1M1_ZeroAdjustment AdjustmentController;
        private Subject observer;
        //private IDatabase Database;

        private static object myLock = new object();

        private BlockingCollection<RawData> _collection;
        private BlockingCollection<RawData> _Graphcollection;

        private static Thread DataCollectorThread;
        private static Thread GraphThread;

        public static List<RawData> FullList;
        public static List<RawData> DownsampledRawList
        {
            get
            {
                lock (myLock)
                {
                    return downsampledRawList;
                }
            }

            private set
            {
                lock (myLock)
                {
                    downsampledRawList = value;
                }
            }
        }

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
        private static List<RawData> downsampledRawList;
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double Average { get; set; }
        private static double Time { get; set; } 


        public DataTreatment(BlockingCollection<RawData> collection,  ConvertAlgo conv) //Database data
        {
            _collection = collection;
            ConvertAlgorithm = conv;
            // Database = data;

            _Graphcollection = new BlockingCollection<RawData>();
            FullList = new List<RawData>();
            //ConvertedDataList = new List<ConvertedData>();
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

        public void MakeShortRawList2()
        {
            while (!ShallStop)
            {
                for (int i = 0; i < 1000; i++)
                {
                    FullList.Add(_collection.Take()); // Adds 1000 samples into the treatment list. This is equivalent to 1 s worth of data from the transducer
                }

                if (FullList.Count >= 2000 && DownsampledRawList.Count < 300)
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count; i += 17) // Starts downsampling from the 1000th measured sample. Downsampling 17 (8+1+8)
                    {
                        Total = 0;
                        Average = 0;

                        Total = FullList[i - 8].Voltage + FullList[i - 7].Voltage + FullList[i - 6].Voltage + FullList[i - 5].Voltage
                                + FullList[i - 4].Voltage + FullList[i - 3].Voltage + FullList[i - 2].Voltage + FullList[i - 1].Voltage
                                + FullList[i].Voltage + FullList[i + 1].Voltage + FullList[i + 2].Voltage + FullList[i + 3].Voltage
                                + FullList[i + 4].Voltage + FullList[i + 5].Voltage + FullList[i + 6].Voltage + FullList[i + 7].Voltage
                                + FullList[i + 8].Voltage; // Finds sum of voltage value of points in question

                        Average = Total / 17; // Finds average
                        Time++;

                        DownsampledRawList.Add(new RawData(Time, Average)); // Saves average and time to downsampled list. The downsampled list is used for the filter.
                    }
                }

                if (DownsampledRawList.Count == 236)
                {
                    Thread.Sleep(50);
                }

            }
        }


        public void MakeGraphList2()
        {
            while (!ShallStop)
            {
                Thread.Sleep(70);

                //if (60 <= DownsampledRawList.Count && DownsampledRawList.Count <= 300)
                if (DownsampledRawList.Count == 236)
                {
                    Done();

                    for (int i = DownsampledRawList.Count - 60; i < DownsampledRawList.Count; i++)
                    {
                        int graphcounter=+1;
                        //GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, ConvertAlgorithm.ConvertData(DownsampledRawList[i].Voltage)));
                        //GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage));
                        GraphList.Add(new ConvertedData(graphcounter, DownsampledRawList[i].Voltage));
                        DownsampledRawList.RemoveAt(i);

                    }
                    // Done();
                }
            }
        }


        public void MakeShortRawList() // Lav en observer som fortæller når den er fuld
        {
            while (!ShallStop)
            {
                for (int i = 0; i < 1000; i++)
                {
                    FullList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                }

                if (FullList.Count >= 1000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000; i < FullList.Count-16; i += 17) // Runs to full count minus 16, because otherwise the downsampling would stop. Does this mean we loose 16 points of data / one downsampled point?
                    {
                        Total = 0;
                        Average = 0;

                        Total = FullList[i].Voltage + FullList[i + 16].Voltage + FullList[i + 15].Voltage +
                                FullList[i + 14].Voltage + FullList[i + 13].Voltage + FullList[i + 12].Voltage + FullList[i + 11].Voltage + FullList[i + 10].Voltage + FullList[i + 9].Voltage
                                + FullList[i + 8].Voltage + FullList[i + 7].Voltage + FullList[i + 6].Voltage + FullList[i + 5].Voltage + FullList[i + 4].Voltage + FullList[i + 3].Voltage
                                + FullList[i + 2].Voltage + FullList[i + 1].Voltage;

                        Average = (Total / 17); // Average = (Total / 17) - zeroValue;
                        Time++; ;

                        _Graphcollection.Add(new RawData(0,Average));

                        //if (downsampledRawList.Count < 300)
                        //{
                            //downsampledRawList.Add(new RawData(0, Average)); // Its added to the property in order for it to be safe
                        //}
                    }
                }

                Thread.Sleep(20);
            }
        
        } 

        public void MakeGraphList()
        {
            while(!ShallStop)
            {
                Thread.Sleep(20);

                if (graphList.Count < 300)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        graphList.Add(new ConvertedData(0, ConvertAlgorithm.ConvertData(_Graphcollection.Take().Voltage)));
                    }

                    Done();
                }

                if (graphList.Count == 300)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        graphList.RemoveAt(i);
                    }
                }

                //if (downsampledRawList.Count >= 60 && downsampledRawList.Count < 300)
                //{
                //    for (int i = downsampledRawList.Count - 60; i < downsampledRawList.Count; i++)
                //    {
                //        graphList.Add(new ConvertedData(downsampledRawList[i].Second, ConvertAlgorithm.ConvertData(downsampledRawList[i].Voltage)));
                //    }

                //    if (graphList.Count == 60 || graphList.Count == 120 || graphList.Count == 180 || graphList.Count == 240)
                //    {
                //        Done();
                //    }
                //}

                //if (graphList.Count == 300 && downsampledRawList.Count ==300)
                //{
                //    Done();

                //    for (int i = 0; i < 60; i++)
                //    {
                //        downsampledRawList.RemoveAt(i);
                //        graphList.RemoveAt(i);
                //    }
                //}

                //if (downsampledRawList.Count == 300 && graphList.Count == 300)
                //if (downsampledRawList.Count == 300)
                //{
                //    Done();

                //    for (int i = 0; i < 60; i++)
                //    {
                //        downsampledRawList.RemoveAt(i);
                //        graphList.RemoveAt(i);
                //    }
                //}

                //if (graphList.Count == 60 || graphList.Count == 120 || graphList.Count == 180 || graphList.Count == 240) 
                //{
                //    Done();
                //}

                //if (downsampledRawList.Count == 300)
                //{
                //    Done();

                //    for (int i = 0; i < 60; i++)
                //    {
                //        downsampledRawList.RemoveAt(i);
                //        graphList.RemoveAt(i);
                //    }
                //}
            }
        }
        public List<ConvertedData> GetGraphList() 
        {
            return graphList;
        }

        public List<RawData> GetFilterList() // Skal returnere det nedsamplede rådata fratrukket nulpunktsjusteringen
        {
            return downsampledRawList;
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
