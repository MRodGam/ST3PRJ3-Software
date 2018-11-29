using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BloodPressure
    {
        public double Systolic { get;  }
        public double Diastolic { get; }
        public double Mean { get; }

        public BloodPressure(double systolic, double diastolic, double mean)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Mean = mean;
        }

        public BloodPressure()
        {
            Systolic = 0;
            Diastolic = 0;
            Mean = 0;
        }
    }
}
