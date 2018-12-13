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

        private ICalibrate _calibrate;
        private IData DataInterface;

        // Objects 
        private static object myLock = new object();

        // Blocking collections
        private BlockingCollection<RawData> _collection; // Take from TransducerDAQ
        private BlockingCollection<RawData> _graphCollection; // Take from DataTreamtment, Add to graphList 
        private BlockingCollection<RawData> _filterCollection;

        // Threads
        private static Thread DataCollectorThread; // Datacollection thread (downsampling)
        private static Thread GraphThread; // Rotating graph list (convertion)

        // Lists
        public List<RawData> FullList { get; private set; } // Complete measurement

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
        } // Downsampled list (with a Lock)

        private static List<RawData> downsampledRawList; // Same list defined as an attribute, this is necessary in order to put a lock on it

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
        } // Converted list (with a Lock)

        private static List<ConvertedData> graphList; // Same list defined as an attribute, this is necessary in order to put a lock on it

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
        public DataTreatment(BlockingCollection<RawData> collection, BlockingCollection<RawData> graphCollection,ConvertAlgo conv,IData data)
        {
            _collection = collection;
            _graphCollection = graphCollection;
            DataInterface = data;
            //_filterCollection = filterCollection;
            

            //DataInterface = iData;
            ConvertAlgorithm = conv;

            FullList = new List<RawData>();
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

        public void MakeShortRawList() // Lav en observer som fortæller når den er fuld
        {
            zeroadjustmentVal = AdjustmentController.GetZeroAdjustmentValue();

            while (!ShallStop)
            {
                for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time
                {
                    FullList.Add(_collection.Take()); // Adda 1000 samples into the treatment list.
                }

                if (FullList.Count >= 1000) // If the list is longer than the 5 sec window in the graph
                {
                    for (int i = FullList.Count - 1000;
                        i < FullList.Count - 16;
                        i += 17) // Runs to full count minus 16, because otherwise the downsampling would stop. Does this mean we loose 16 points of data / one downsampled point?
                    {
                        Total = 0;
                        ZeroAdjustedAverage = 0;

                        Total = FullList[i].Voltage + FullList[i + 16].Voltage + FullList[i + 15].Voltage +
                                FullList[i + 14].Voltage + FullList[i + 13].Voltage + FullList[i + 12].Voltage +
                                FullList[i + 11].Voltage + FullList[i + 10].Voltage + FullList[i + 9].Voltage
                                + FullList[i + 8].Voltage + FullList[i + 7].Voltage + FullList[i + 6].Voltage +
                                FullList[i + 5].Voltage + FullList[i + 4].Voltage + FullList[i + 3].Voltage
                                + FullList[i + 2].Voltage + FullList[i + 1].Voltage;

                        //ZeroAdjustedAverage = (Total / 17) - zeroadjustmentVal;
                        ZeroAdjustedAverage = (Total / 17);

                        _graphCollection.Add(new RawData(0, ZeroAdjustedAverage)); // There is not added a time stamp.
                        // _filterCollection.Add(new RawData(0, ZeroAdjustedAverage));
                    }
                }
            }
        }

        public void MakeGraphList()
        {
            //calibrationVal = DataInterface.GetCalibrateValue();
            calibrationVal = new CalibrationValue(0.0189, -1.975);

            while (!ShallStop)
            {
                if (graphList.Count < 300)
                {
                    for (int i = 0; i < 60; i++) // Adds 60 datapoints at a time
                    {
                        ConvertedValue = ConvertAlgorithm.ConvertData(_graphCollection.Take().Voltage, calibrationVal);
                        graphList.Add(new ConvertedData(0, ConvertedValue)); // Takes from graphCollection and converts to mmHg
                    }

                    Done(); // Updates graph
                }

                if (graphList.Count == 300)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        graphList.RemoveAt(i); // Removes the earliest 60 points
                    }
                }
            }
        }
        

        public List<ConvertedData> GetGraphList()
        {
            return graphList;
        }

        public List<RawData> GetDownsampledList()
        {
            return downsampledRawList;
        }

        public List<RawData> GetFullList()
        {
            return FullList;
        }
    }
}
