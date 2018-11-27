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
        private CalibrationValue calibration;

        public double ConvertData(double second, double voltage)
        {
            // Calculate pressure from voltage
            Voltage = voltage;
            Second = second;

            return Pressure =  Voltage * calibration.Value;
            
        }



    }
}
