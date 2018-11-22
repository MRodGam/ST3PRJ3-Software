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
    public class UC7S3_Filter : IFilter //midlingsfilter 
    {
        public List<RawData> BPFilter;
        public DataTreatment datatreatment_;
        public static bool ShallStop { get; private set; }
        private static Thread FilterThread;

        public UC7S3_Filter(DataTreatment datatreatment)
        {
            datatreatment_ = datatreatment;
            BPFilter = new List<RawData>();
            FilterThread = new Thread(FilterData);
        }

        public void StartFilter()
        {
            //sættes fra eventhandler 
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
                List<RawData> BPRawData = datatreatment_.GetFilterList();

                for (int i = 2; i < BPRawData.Count; i++)
                {
                    if (i + 2 < BPRawData.Count)
                    {
                        BPFilter.Add(new RawData(BPRawData[i - 2].Second, (BPRawData[i - 2].Voltage + BPRawData[i - 1].Voltage +
                                                                           BPRawData[i].Voltage + BPRawData[i + 1].Voltage + BPRawData[i + 2].Voltage) / 5));
                    }
                }
            }  
        }

        public List<RawData> GetFilterData()
        {
            return BPFilter;
        }

    }
}
