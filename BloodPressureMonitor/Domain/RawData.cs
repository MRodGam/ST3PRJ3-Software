½using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RawData
    {
        public double Second { get; set; }
        public double Voltage { get; set; }

        public RawData(double second, double voltage)
        {
            Second = second;
            Voltage = voltage;
        }
    }
}
