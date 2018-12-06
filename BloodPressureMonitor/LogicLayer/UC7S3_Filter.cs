using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC7S3_Filter : IFilter //: IDataTreatment //midlingsfilter 
    {
        public List<RawData> BPFilterList { get; set; };
        public DataTreatment datatreatment_;
        public bool ShallStop { get; private set; }
        private static Thread FilterThread;

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

        private static List<ConvertedData> graphList; // bliver denne brugt?

        public UC7S3_Filter(DataTreatment datatreatment)
        {
            datatreatment_ = datatreatment;
            BPFilterList = new List<RawData>();
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
            while (!ShallStop)
            {
                List<RawData>
                    BPRawData = datatreatment_.GetDownsampledList(); // Skift til converted data  DTO type, for ellers giver det ballade i GUI

                for (int i = 2; i < BPRawData.Count; i++)
                {
                    if (i + 2 < BPRawData.Count)
                    {
                        BPFilterList.Add(new RawData(BPRawData[i - 2].Second,
                            (BPRawData[i - 2].Voltage + BPRawData[i - 1].Voltage +
                             BPRawData[i].Voltage + BPRawData[i + 1].Voltage + BPRawData[i + 2].Voltage) / 5));
                    }
                }

                //return BPFilterList;
                // Send data op her
            }
            
        }

        public void ConvertFiltredData()
        {
            while (!ShallStop)
            {
                //Thread.Sleep(20);

                // if (60 < DownsampledRawList.Count && DownsampledRawList.Count < 300)
                if (60 <= BPFilterList.Count)
                {
                    for (int i = BPFilterList.Count - 60; i < BPFilterList.Count; i++)
                    {
                        GraphFiltredList.Add(new ConvertedData(DownsampledRawList[i].Second, ConvertAlgorithm.ConvertData(DownsampledRawList[i].Voltage)));
                        //GraphList.Add(new ConvertedData(DownsampledRawList[i].Second, DownsampledRawList[i].Voltage));
                    }

                    Done();
                }
            }

        //    public List<RawData> ConvertFiltredData()
        //{
        //    return 
        //}

        //public List<RawData> GetFilterData() // Skal slettes, skal ikke være en metode for sig
        //{
        //    return BPFilter; //Skal retuneres på en tråd
        //}

        // metode der laver grafliste for filtreret data
    }



}
