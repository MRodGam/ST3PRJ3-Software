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
    class UC2M2_UC3M3_Measure
    {
        public IDAQ Daq;

        public UC2M2_UC3M3_Measure(IDAQ daq)
        {
            Daq = daq;
        }

        public void StartMeasurement()
        {
            Daq.Start();
        }

        public void StopMeasurement()
        {
            Daq.Stop();
        }
    }
}
