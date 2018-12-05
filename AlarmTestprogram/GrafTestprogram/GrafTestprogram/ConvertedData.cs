using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConvertedData
    {
        public double Second { get; set; }
        public double Pressure { get; set; }


        public ConvertedData(double second, double pressure)
        {
            Second = second;
            Pressure = pressure;
        }
    }
}
