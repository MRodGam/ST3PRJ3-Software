using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class FilterAlgo
    {
        public List<RawData> BPFilter;
        public List<RawData> GetRawDatas()
        {
            List<RawData> BPFilterData = .GetRawDatas(); //Mangler DAQ objekt?
            BPFilter = new List<RawData>();

            for (int i = 2; i < BPFilter.Count; i++)
            {
                if (i + 2 < BPFilter.Count)
                {
                    BPFilter.Add(new RawData(BPFilterData[i-2].Second, (BPFilterData[i - 2].Voltage + BPFilterData[i-1].Voltage + 
                                               BPFilterData[i].Voltage + BPFilterData[i+1].Voltage + BPFilterData[i+2].Voltage) / 5));
                }
            }

            return BPFilterData;
        }
    }
}
