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
    public class UC7S3_Filter : Subject //: IDataTreatment //midlingsfilter 
    {

        // Classes and interfaces
        private ConvertAlgo convertAlgo;
        public DataTreatment datatreatment_;
        private CalibrationValue _CalibrationValue;
        private IData DataInterface;

        // Threads
        private static Thread FilterThread;
        
        // Blocking collection
        private BlockingCollection<ConvertedData> _filterCollection;
        // Objects
        private static object myLock = new object();

        // Lists
        public List<ConvertedData> BPFilterList { get; set; }
        public List<RawData> BPRawList { get; set; }
        public static List<ConvertedData> GraphFiltredList
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
        private static List<ConvertedData> graphFiltredList; // bliver denne brugt?

        // Properties
        public bool ShallStop { get; private set; }
        public double FilteredVoltage { get; private set; }
        public double calibrationVal { get; private set; }

        public UC7S3_Filter(BlockingCollection<ConvertedData> filterCollection, DataTreatment datatreatment, IData dataInterface, ConvertAlgo conv)
        {
            _filterCollection = filterCollection;
            datatreatment_ = datatreatment;
            DataInterface = dataInterface;

            convertAlgo = conv;
            BPFilterList = new List<ConvertedData>();
            FilterThread = new Thread(FilterData);

            GraphFiltredList = new List<ConvertedData>();
        }

        public void StartFilter()
        {
            //Skal sættes fra eventhandler 
            ShallStop = false;
            FilterThread.Start();
        }

        public void StopFilter()
        {
            ShallStop = true;
        }

        public void FilterData()
        {
            calibrationVal = DataInterface.GetCalibrateValue();

            while (!ShallStop)
            {
                for (int i = 0; i < 60; i++)
                {
                    BPRawList.Add(new RawData(0,_filterCollection.Take().Pressure));
                }

                for (int i = 2; i < BPRawList.Count; i++)
                {
                    if (i + 2 < BPRawList.Count)
                    {
                        FilteredVoltage = (BPRawList[i - 2].Voltage + BPRawList[i - 1].Voltage + BPRawList[i].Voltage + BPRawList[i + 1].Voltage + BPRawList[i + 2].Voltage) / 5;
                        BPFilterList.Add(new ConvertedData(0,convertAlgo.ConvertData(FilteredVoltage, calibrationVal)));
                    }
                }

                Done();
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


        public List<ConvertedData> GetFiltredGraphList()
        {
            return BPFilterList;
        }

        public void Done()
        {
            Notify();
        }

    }
}
