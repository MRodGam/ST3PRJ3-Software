using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CalibrationValue
    {
        public double Value { get; set; }

        public CalibrationValue(double calibrationValue)
        {
            Value = calibrationValue;
        }
    }
}
