using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BloodPressure
    {
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public double Mean { get; set; }

        public BloodPressure(double systolic, double diastolic, double mean)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Mean = mean;
        }
    }
}
