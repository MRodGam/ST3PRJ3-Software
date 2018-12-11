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
        //private CalibrationValue calibration;
        public double CalibrationValue { get; private set; }
        

        public double ConvertData(double voltage, double cal)
        {
            // Calculate pressure from voltage
            Voltage = voltage;
            CalibrationValue = cal;

            return Pressure = Voltage * 10;

        }



    }
}
