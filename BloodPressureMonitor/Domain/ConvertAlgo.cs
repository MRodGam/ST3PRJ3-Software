using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConvertAlgo
    {
        public double Second { get; private set; }
        public double Voltage { get; private set; }
        public double Pressure { get; private set; }

        public void ConvertData(double second, double voltage)
        {
            Second = second;
            Voltage = voltage;
            
            // Calculate pressure from voltage
        }
    }
}
