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
        public double calibrationValue { get; private set; }

        public double ConvertData(double voltage)
        {
            // calibrationValue = cal;
            Voltage = voltage;
            // Second = second;

            //return Pressure = Voltage * calibrationValue;
            return Pressure = Voltage * 1;
        }



    }
}
