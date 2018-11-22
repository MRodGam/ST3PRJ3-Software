using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC6S2_Calibrate : ICalibrate
    {
       
        private BlockingCollection<RawData> _collection;
        private List<RawData> voltageList = new List<RawData>();
        private CalibrationValue _calibration;

        private double[] voltageArray = new double[4];
        private double[] pressureArray = new double[4];
        private int _tæller = 0;
        private double _voltagePoint;
        

        public UC6S2_Calibrate(BlockingCollection<RawData> collection)
        {
            _collection = collection;

        }

        public void AddVoltageValue(int pressureValue) // metoden der kaldes i eventhandleren for hver volt måling 
        {
            
            double voltageValue = GetOneVoltagePoint();
            addSample(voltageValue, pressureValue);


        }

        public double GetOneVoltagePoint() // køres for hver volt måling (kaldes i metoden AddVoltage()
        {
            UC2M2_UC3M3_Measure measure = new UC2M2_UC3M3_Measure();
            double totalVoltageValue = 0;
            double _voltagePoint = 0.0;
            
            
            measure.StartMeasurement(); // start måling 

            //voltageList.AddRange(_collection.Take()); // Tilføj samples til liste, OBS virker ikke? 
            
         
            //for (int i = 0; i < voltageList.Count; i++)
            //{
            //    totalVoltageValue = voltageList[i] + totalVoltageValue; // samlet værdi for volt findes
            //}

            _voltagePoint = _collection.Take().Voltage;

            if (_voltagePoint != 0.0)
            {
                measure.StopMeasurement();// slutter måling 
            }
            
            return _voltagePoint;
        }

        public void addSample(double voltage, int pressure) // OBS vil gerne kunne returnere de to arrays i metoden??
        {
            if (_tæller == 5) 
            {
                _tæller = 0;
            }

            voltageArray[_tæller] = voltage; // tilføjer volt værdi i array
            pressureArray[_tæller] = pressure; // tilføjer tryk-værdi i array
            _tæller++;
        }


        //lineær regrssion 

        // finde hældningen på a, som skal ganges på alle målingerne --> algoritmen 

        // x-aksen er volt og y-aksen er mmHg

        // vi sender et kendt tryk ind, og måler volten for det -> dette er hvad der kommer på x-aksen
        // det systemet måler for det der sendes ind er hvad der er på y-aksen -> eller er de fast besluttet?

        // hældningen for den graf der laves ud fra de punkter der kommer fra målingen, skal ganges på den volt der kommer ind i systemet, og dette er måden man omregner til mmHg


        public void DoCalibrateRegression()
        {
            // regressions kode
            double[] volt = new double[] {voltageArray[0], voltageArray[1], voltageArray[2], voltageArray[3], voltageArray[4]};
            double[] pressure = new double[] {pressureArray[0],pressureArray[1], pressureArray[2],pressureArray[3],pressureArray[4]};

            double n = volt.Length;
            double sumxy = 0, sumx = 0, sumy = 0, sumx2 = 0;
            for (int i = 0; i < volt.Length; i++)
            {
                sumxy += volt[i] * pressure[i];
                sumx += volt[i];
                sumy += pressure[i];
                sumx2 += volt[i] * volt[i];

            }
            
            double a = ((sumxy-sumx*sumy/n) / (sumx2-sumx*sumx/n) ); // _a er hældningskoefficienten som skal ganges på alle volt værdierne 
            
            _calibration = new CalibrationValue(a); // sætter CalibrationsValue til _a

        }

    }
}
