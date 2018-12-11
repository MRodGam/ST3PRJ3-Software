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
        public PulseAlgo pulseAlgorithm;
        public double[] rawDataArray;
        public int pulse;


        public UC8S4_Pulse(DataTreatment _dataTreatment)
        {
            dataTreatment = _dataTreatment;
        }

        public int FindPulse() 
        {
            RawDataList = dataTreatment.GetFullList(); // skal det ikke være en GetFullList her? 

            for (int i = 0; i < RawDataList.Count; i++)
            {
                rawDataArray[i] = RawDataList[i].Voltage;
            }

            pulse = pulseAlgorithm.Pulse(rawDataArray, 1000);

            return pulse;

        }

        public int Pulse(double[] measurements, double samplefrequence)
        {
            throw new NotImplementedException();
        }
    }
}
