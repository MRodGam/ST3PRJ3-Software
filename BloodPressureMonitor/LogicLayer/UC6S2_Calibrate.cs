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
        private CalibrationValue _calibration;
        private IMeasure Measure;
        private IData Database;
        private ConvertedData ConvertData;

        private double[] voltageArray = new double[5]; // array indeholder 5 pladser da vi tager fem målinger i kalibreringen
        private double[] pressureArray = new double[5];

        private int _tæller = 0;
        private double _voltagePoint;
        private double caliValue;

        public bool IsAll5MeasureDone = false;
        
        public UC6S2_Calibrate(BlockingCollection<RawData> collection, IMeasure measure, IData database, ConvertedData convertData)
        {
            _collection = collection;
            Measure = measure;
            Database = database;
            ConvertData = convertData;

        }

        public void AddVoltageValue(int pressureValue) // metoden der kaldes i eventhandleren for hver volt måling 
        {
            
            double voltageValue = GetOneVoltagePoint();
            addSample(voltageValue, pressureValue);


        }

        public double GetOneVoltagePoint() // køres for hver volt måling (kaldes i metoden AddVoltage()
        {
            
            //UC2M2_UC3M3_Measure measure = new UC2M2_UC3M3_Measure();
            double totalVoltageValue = 0;
            double _voltagePoint = 0.0;
            
            
            Measure.StartMeasurement(); // start måling 

            //voltageList.AddRange(_collection.Take()); // Tilføj samples til liste, OBS virker ikke? 
            
         
            //for (int i = 0; i < voltageList.Count; i++)
            //{
            //    totalVoltageValue = voltageList[i] + totalVoltageValue; // samlet værdi for volt findes
            //}

            _voltagePoint = _collection.Take().Voltage; 

            if (_voltagePoint != 0.0)
            {
                Measure.StopMeasurement();// slutter måling 
            }
            
            return _voltagePoint;
        }

        public void addSample(double voltage, int pressure) // OBS vil gerne kunne returnere de to arrays i metoden??
        {
            if (_tæller == 5) 
            {
                _tæller = 0;
                IsAll5MeasureDone = false;
            }

            voltageArray[_tæller] = voltage; // tilføjer volt værdi i array
            pressureArray[_tæller] = pressure; // tilføjer tryk-værdi i array
            _tæller++;
            if (_tæller == 5)
            {
                IsAll5MeasureDone = true;
            }
        }

        public bool GetIsAll5MeasureDone()
        {
            return IsAll5MeasureDone;
        }

        //lineær regrssion 

        // finde hældningen på a, som skal ganges på alle målingerne --> algoritmen 

        // x-aksen er volt og y-aksen er mmHg

        // vi sender et kendt tryk ind, og måler volten for det -> dette er hvad der kommer på x-aksen
        // det systemet måler for det der sendes ind er hvad der er på y-aksen -> eller er de fast besluttet?

        // hældningen for den graf der laves ud fra de punkter der kommer fra målingen, skal ganges på den volt der kommer ind i systemet, og dette er måden man omregner til mmHg


        public void DoCalibrateRegression()
        {
            caliValue = 0;
           
            // regressions kode
            double n = voltageArray.Length;
            double sumxy = 0, sumx = 0, sumy = 0, sumx2 = 0;
            for (int i = 0; i < voltageArray.Length; i++)
            {
                sumxy += voltageArray[i] * pressureArray[i];
                sumx += voltageArray[i];
                sumy += pressureArray[i];
                sumx2 += voltageArray[i] * voltageArray[i];

            }
            
            caliValue = ((sumxy-sumx*sumy/n) / (sumx2-sumx*sumx/n) ); // _a er hældningskoefficienten som skal ganges på alle volt værdierne 

            // skal gemmes ned i en databasen

            _calibration = new CalibrationValue(caliValue); // sætter CalibrationsValue til _a
          
            Database.SaveCalibrateValue(caliValue); // kalder metoden SaveCalibration i Database gennem interface, og gemmer herved værdien for kalibreringen 

        }

        public double getCalibrateValue()
        {
            return caliValue;
        }

    }
}
