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
        public IDAQ Daq;

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
