using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC7S3_Filter : Subject, IFilter
    {

        // Classes and interfaces
        private ConvertAlgo convertAlgo;
        private CalibrationValue _CalibrationValue;
        private IData DataInterface;

        // Threads
        private static Thread FilterThread;
        
        // Blocking collection
        private BlockingCollection<double> _filterCollection;
        // Objects
        private static object myLock = new object();

        // Lists
        public List<double> BPFilterList { get; set; }
        public List<double> BPRawList { get; set; }
        public static List<double> GraphFiltredList
        {
            get
            {
                lock (myLock)
                {
                    return graphFiltredList;
                }
            }

            private set
            {
                lock (myLock)
                {
                    graphFiltredList = value;
                }
            }
        }
        private static List<double> graphFiltredList; // bliver denne brugt?

        // Properties
        public bool ShallStop { get; private set; }
        public double FilteredVoltage { get; private set; }
        public CalibrationValue calibrationVal { get; private set; }
        public double ConvertedValue { get; private set; }

        public UC7S3_Filter(BlockingCollection<double> filterCollection, IData dataInterface, ConvertAlgo conv)
        {
            _filterCollection = filterCollection;
            DataInterface = dataInterface;

            convertAlgo = conv;
            BPFilterList = new List<double>();

            GraphFiltredList = new List<double>();
            BPRawList = new List<double>();
        }

        public void StartFilter()
        {
            //Skal sættes fra eventhandler 
            FilterThread = new Thread(FilterData);
            ShallStop = false;
            FilterThread.Start();
        }

        public void StopFilter()
        {
            ShallStop = true;
        }

        public void FilterData()
        {
            //calibrationVal = DataInterface.GetCalibrateValue();
            calibrationVal = new CalibrationValue(0.0189, -1.975);

            while (!ShallStop)
            {
                if (BPRawList.Count < 300)
                {
                    for (int i = 0; i < 60; i++) // Adds 60 datapoints at a time
                    {
                        BPRawList.Add(_filterCollection.Take()); // Takes from graphCollection and converts to mmHg

                        //if (i + 2 < BPRawList.Count)

                        //{
                        //    FilteredVoltage = (BPRawList[i - 2] + BPRawList[i - 1] + BPRawList[i] + BPRawList[i + 1] + BPRawList[i + 2]) / 5;
                        //    BPFilterList.Add(convertAlgo.ConvertData(FilteredVoltage, calibrationVal));
                        //}
                    }
                    for (int i = 2; i < 58; i++)
                    {
                        FilteredVoltage = (BPRawList[i - 2] + BPRawList[i - 1] + BPRawList[i] + BPRawList[i + 1] + BPRawList[i + 2]) / 5;
                        BPFilterList.Add(convertAlgo.ConvertData(FilteredVoltage, calibrationVal));
                    }

                    Done(); // Updates graph
                }

                if (BPFilterList.Count == 300)
                {
                    Done();

                    for (int i = 0; i < 60; i++)
                    {
                        BPFilterList.RemoveAt(i); // Removes the earliest 60 points
                    }
                }

                //for (int i = 2; i < BPRawList.Count; i++)
                //{
                //    if (i + 2 < BPRawList.Count)
                //    {
                //        FilteredVoltage = (BPRawList[i - 2] + BPRawList[i - 1] + BPRawList[i] + BPRawList[i + 1] + BPRawList[i + 2]) / 5;
                //        BPFilterList.Add(convertAlgo.ConvertData(FilteredVoltage, calibrationVal));
                //    }
                //}

                //Done();

                //if (graphList.Count < 300)
                //{
                //    for (int i = 0; i < 60; i++) // Adds 60 datapoints at a time
                //    {
                //        ConvertedValue = ConvertAlgorithm.ConvertData(_graphCollection.Take(), calibrationVal);
                //        graphList.Add(ConvertedValue); // Takes from graphCollection and converts to mmHg
                //        _alarmCollection.Add(ConvertedValue);
                //    }

                //    Done(); // Updates graph
                //}


                //if (graphList.Count == 300)
                //{
                //    for (int i = 0; i < 60; i++)
                //    {
                //        graphList.RemoveAt(i); // Removes the earliest 60 points
                //    }
                //}
            }

        }

        //public void ConvertFiltredData()
        //{
        //    while (!ShallStop)
        //    {
        //        //Thread.Sleep(20);

        //        // if (60 < DownsampledRawList.Count && DownsampledRawList.Count < 300)
        //        if (60 <= BPFilterList.Count)
        //        {
        //            for (int i = BPFilterList.Count - 60; i < BPFilterList.Count; i++)
        //            {
        //                GraphFiltredList.Add(new ConvertedData(BPFilterList[i].Second, convertAlgo.ConvertData(BPFilterList[i].Second, BPFilterList[i].Voltage, _CalibrationValue.Value)));
                        
        //            }

        //            Done();
        //        }
        //    }
        //}


        public List<double> GetFilteredGraphList()
        {
            return BPFilterList;
        }

        public void Done()
        {
            Notify();
        }

    }
}
