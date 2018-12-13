using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CalibrationValue
    {
        public double _a { get; set; }
        public double _b { get; set; }

        public CalibrationValue(double a, double b)
        {
            _a = a;
            _b = b;
        }
    }
}
