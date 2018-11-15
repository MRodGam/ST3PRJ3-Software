using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC8S4_Pulse : IPulse
    {
        public DataTreatment dataTreatment;
        public List<RawData> RawDataList;
        public double[] rawDataArray;


        public UC8S4_Pulse(DataTreatment _dataTreatment)
        {
            dataTreatment = _dataTreatment;
        }
        public int FindPulse()
        {
            RawDataList= dataTreatment.GetRawData;

            for (int i = 0; i < RawDataList.Count; i++)
            {
                rawDataArray[i] = RawDataList[i].Voltage;
            }

            PulseAlgo.Pulse(rawDataArray, 1000);

        }
    }
}
