using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class BPandPulseMeasurement
    {
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public double Mean { get; set; }
        public int Pulse { get; set; }

        public List<BloodPressure> Raw1000List = new List<BloodPressure>();
        public List<BloodPressure> Converted1000List = new List<BloodPressure>();
        public List<BloodPressure> Filtered1000List= new List<BloodPressure>();

        public BPandPulseMeasurement(double systolic, double diastolic, double mean, int pulse, BloodPressure rawData,
            BloodPressure filteredData, BloodPressure convertedData)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Mean = mean;
            Pulse = pulse;

            Raw1000List.Add(rawData);
            Converted1000List.Add(convertedData);
            Filtered1000List.Add(filteredData);
        }
   
    }
}
