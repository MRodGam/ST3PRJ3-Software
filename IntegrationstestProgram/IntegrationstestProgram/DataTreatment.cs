using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer // Consumer
{
    public class DataTreatment : Subject //IDataTreatment
    {
        // Classes and interfaces
        private ConvertAlgo ConvertAlgorithm;
        // private UC7S3_Filter FilterController;
        private UC1M1_ZeroAdjustment AdjustmentController;
        private IAlarm AlarmController;

        private ICalibrate _calibrate;
        private IData DataInterface;

        // Objects 
        private static object myLock = new object();

        // Blocking collections
        private BlockingCollection<double> _collection; // Take from TransducerDAQ
        private BlockingCollection<double> _graphCollection; // Take from DataTreamtment, Add to graphList 
        private BlockingCollection<double> _filterCollection;
        private BlockingCollection<double> _alarmCollection;

        // Threads
        private static Thread DataCollectorThread; // Datacollection thread (downsampling)
        private static Thread GraphThread; // Rotating graph list (convertion)

        // Lists
        public List<double> FullList
        {
            get
            {
                lock (myLock)
                {
                    return fullList;
                }
            }

            private set
            {
                lock (myLock)
                {
                    fullList = value;
                }
            }
        }
        public List<double> fullList;
        public static List<double> DownsampledRawList
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
        } // Downsampled list (with a Lock)

        private static List<double> downsampledRawList; // Same list defined as an attribute, this is necessary in order to put a lock on it

        public static List<double> GraphList
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
        } // Converted list (with a Lock)

        private static List<double> graphList; // Same list defined as an attribute, this is necessary in order to put a lock on it
        private static List<double> PulseList;

        // Properties
        //public static double CaliValue { get; set; } // mangles at blive sat et sted!
        public static bool ShallStop { get; private set; }
        private static double Total { get; set; }
        private static double ZeroAdjustedAverage { get; set; }
        public CalibrationValue calibrationVal { get; private set; }
        public double zeroadjustmentVal { get; private set; }
        public double ConvertedValue { get; private set; }

        //
        //

        //public DataTreatment(BlockingCollection<RawData> collection, BlockingCollection<RawData> graphCollection, BlockingCollection<RawData> filterCollection, IData iData, ConvertAlgo conv)
        public DataTreatment(BlockingCollection<double> collection, BlockingCollection<double> graphCollection, BlockingCollection<double> filterCollection,
            BlockingCollection<double> alarmCollection, ConvertAlgo conv, IData data, IAlarm alarm)
        {
            _collection = collection;
            _graphCollection = graphCollection;
            _filterCollection = filterCollection;
            _alarmCollection = alarmCollection;

            DataInterface = data;
            //_filterCollection = filterCollection;
            AlarmController = alarm;
            

            //DataInterface = iData;
            ConvertAlgorithm = conv;

            FullList = new List<double>();
            DownsampledRawList = new List<double>();
            GraphList = new List<double>();
            PulseList = new List<double>();
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

        public void MakeShortRawList() // Lav en observer som fortæller når den er fuld
        {
            //zeroadjustmentVal = AdjustmentController.GetZeroAdjustmentValue();
            zeroadjustmentVal = -1.989;

            while (!ShallStop)
            {
                for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time
                {
                    fullList.Add(_collection.Take()); // Adda 1000 samples into the treatment list.
                }

                if (fullList.Count >= 1000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = fullList.Count - 1000;
                        i < fullList.Count - 16;
                        i += 17) // Runs to full count minus 16, because otherwise the downsampling would stop. Does this mean we loose 16 points of data / one downsampled point?
                    {
                        Total = 0;
                        ZeroAdjustedAverage = 0;

                        Total = fullList[i] + fullList[i + 16] + fullList[i + 15] +
                                fullList[i + 14]+ fullList[i + 13] + fullList[i + 12] +
                                fullList[i + 11] + fullList[i + 10] + fullList[i + 9]
                                + fullList[i + 8] + fullList[i + 7] + fullList[i + 6] +
                                fullList[i + 5] + fullList[i + 4]  + fullList[i + 3]
                                + fullList[i + 2] + fullList[i + 1];

                        //ZeroAdjustedAverage = (Total / 17) - zeroadjustmentVal;
                        ZeroAdjustedAverage = (Total / 17)-zeroadjustmentVal;

                        _graphCollection.Add(ZeroAdjustedAverage); // There is not added a time stamp.
                        _filterCollection.Add(ZeroAdjustedAverage);
                    }
                }
            }
        }

        public void MakeGraphList()
        {
            calibrationVal = DataInterface.GetCalibrateValue();

            while (!ShallStop)
            {
                if (graphList.Count < 300)
                {
                    for (int i = 0; i < 60; i++) // Adds 60 datapoints at a time
                    {
                        ConvertedValue = ConvertAlgorithm.ConvertData(_graphCollection.Take(), calibrationVal);
                        graphList.Add(ConvertedValue); // Takes from graphCollection and converts to mmHg
                        _alarmCollection.Add(ConvertedValue);
                    }

                    Done(); // Updates graph
                }


                if (graphList.Count == 300)
                {
                    Done();

                    for (int i = 0; i < 60; i++)
                    {
                        graphList.RemoveAt(i); // Removes the earliest 60 points
                    }
                }
            }
        }
        

        public List<double> GetGraphList()
        {
            return graphList;
        }

        public List<double> GetDownsampledList()
        {
            return downsampledRawList;
        }

        public List<double> GetFullList()
        {
            return fullList;
        }
    }
}
