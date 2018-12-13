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
        public double CalibrationValue { get; private set; }
        public double a { get; private set; }
        public double b { get; private set; }
        

        public double ConvertData(double voltage, CalibrationValue cal)
        {
            a = cal._a;
            b = cal._b;

            // Calculate pressure from voltage
            Voltage = voltage;
            //CalibrationValue = cal;

            return Pressure = (Voltage/a)-b;
            
        }



    }
}
