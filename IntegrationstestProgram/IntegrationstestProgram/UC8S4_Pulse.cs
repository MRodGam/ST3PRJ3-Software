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
        public List<double> RawDataList;
        public PulseAlgo pulseAlgorithm;
        public double[] rawDataArray;
        public int pulse;


        public UC8S4_Pulse(DataTreatment _dataTreatment, PulseAlgo pulse)
        {
            dataTreatment = _dataTreatment;
            pulseAlgorithm = pulse;
        }

        public int FindPulse() 
        {
            RawDataList = dataTreatment.GetFullList(); // skal det ikke være en GetFullList her?
            rawDataArray = RawDataList.ToArray();


            pulse = pulseAlgorithm.Pulse(rawDataArray, 15000); //20.000 er antal samples det regner henover

            return pulse;
        }


    }
}
