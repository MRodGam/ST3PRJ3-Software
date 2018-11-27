using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC2M2_UC3M3_Measure : IMeasure
    {
        private IDAQ Daq;
        private DataTreatment dataTreatment;

        public UC2M2_UC3M3_Measure(IDAQ actualDaq, DataTreatment _dataTreatment)
        {
            Daq = actualDaq;
            dataTreatment = _dataTreatment;
        }
        public void StartMeasurement()
        {
            Daq.Start();
            dataTreatment.StartGraph();
        }

        public void StopMeasurement()
        {
            Daq.Stop();
            dataTreatment.StopGraph();
        }
    }
}
