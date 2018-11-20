using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC6S2_Calibrate : ICalibrate
    {
        //lineær regrssion 

        // finde hældningen på a, som skal ganges på alle målingerne --> algoritmen 

        // x-aksen er volt og y-aksen er mmHg

        // vi sender et kendt tryk ind, og måler volten for det -> dette er hvad der kommer på x-aksen
        // det systemet måler for det der sendes ind er hvad der er på y-aksen -> eller er de fast besluttet?

        // hældningen for den graf der laves ud fra de punkter der kommer fra målingen, skal ganges på den volt der kommer ind i systemet, og dette er måden man omregner til mmHg
        private BlockingCollection<RawData> _collection;
        private List<double> voltageList = new List<double>();

        private double[] voltageArray = new double[4];
        private int _tæller = 0;
        private double _voltagePoint;

        public UC6S2_Calibrate(BlockingCollection<RawData> collection)
        {
            _collection = collection;

        }

        public double GetOneVoltagePoint()
        {
            double totalVoltageValue = 0;
            double _voltagePoint;

            voltageList.AddRange(_collection.Take()); // virker ikke? 
          
         
            for (int i = 0; i < voltageList.Count; i++)
            {
                totalVoltageValue = voltageList[i] + totalVoltageValue; // samlet værdi for volt findes
            }

            _voltagePoint = (totalVoltageValue / voltageList.Count); // gennemsnittet for volt-værdierne findes
            
            return _voltagePoint;
        }

        public void addSample(double voltagePoint)
        {
            voltagePoint = _voltagePoint;

            if (_tæller == 5)
            {
                _tæller = 0;
            }

            voltageArray[_tæller] = voltagePoint; // tilføjer volt værdi i array
            _tæller++;
        }

        public double DoCalibrateRegression(double[] Volt, double[] Pressure)
        {
            // regression
            Volt = new double[] {voltageArray[0], voltageArray[1], voltageArray[2], voltageArray[3], voltageArray[4]};
            Pressure = new double[] {10, 30, 50, 75, 100};

            Tuple<double, double> p = FitLine(Volt, Pressure);
            double a = p.Item1;
            double b = p.Item2;

            return a;
        }

    }
}
