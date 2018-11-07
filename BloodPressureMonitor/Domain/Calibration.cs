using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Calibration
    {
        public double CalibrationValue { get; set; }

        public Calibration(double calibrationValue)
        {
            CalibrationValue = calibrationValue;
        }
    }
}
