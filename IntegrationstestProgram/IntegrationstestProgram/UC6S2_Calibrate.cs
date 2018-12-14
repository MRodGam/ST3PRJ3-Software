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
       
        private BlockingCollection<double> _calibrateCollection;
        private CalibrationValue _calibration;
        private IDAQ _daq;
        private IData Database;
        private double ConvertData;

        private double[] voltageArray = new double[5]; // array indeholder 5 pladser da vi tager fem målinger i kalibreringen
        private double[] pressureArray = new double[5];

        private int _tæller = 0;
        private double _voltageSum;
        private double _voltagePoint;
        private double a;
        private double a1;
        private double b;
        private double b1;
        private string today = DateTime.Today.ToString("d/MM/yyyy");

        public bool IsAll5MeasureDone = false;
        
        public UC6S2_Calibrate(BlockingCollection<double> calibrateCollection, IDAQ daq, IData database)
        {
            _calibrateCollection = calibrateCollection;
            _daq = daq;
            Database = database;
            //ConvertData = convertData;

        }

        public void AddVoltageValue(int pressureValue) // metoden der kaldes i eventhandleren for hver volt måling 
        {
            double voltageValue = GetOneVoltagePoint();
            addSample(voltageValue, pressureValue);
        }

        public double GetOneVoltagePoint() // køres for hver volt måling (kaldes i metoden AddVoltage()
        {
            double totalVoltageValue = 0;
            double _voltagePoint = 0.0;
            _voltageSum = 0;
            
            _daq.StartCalibration(); // start måling 

            //voltageList.AddRange(_collection.Take()); // Tilføj samples til liste, OBS virker ikke? 
            
         
            //for (int i = 0; i < voltageList.Count; i++)
            //{
            //    totalVoltageValue = voltageList[i] + totalVoltageValue; // samlet værdi for volt findes
            //}
            for (int i = 0; i < 1000; i++)
            {
                _voltageSum += _calibrateCollection.Take();
            }

            _voltagePoint = _voltageSum / 1000;

            if (_voltagePoint != 0.0)
            {
                // _daq.Stop();// slutter måling 
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
            a1 = 0;
            a = 0;
            b1 = 0;
            b = 0;
           
            // regressions kode
            double n = voltageArray.Length;
            double sumxy = 0, sumx = 0, sumy = 0, sumx2 = 0;
            for (int i = 0; i < voltageArray.Length; i++)
            {
                sumxy += voltageArray[i] * pressureArray[i];
                sumx += pressureArray[i];
                sumy += voltageArray[i];
                sumx2 += pressureArray[i] * pressureArray[i];

            }
            
            a1 = ((sumxy/n)-((sumx/n)*(sumy/n))) / ((sumx2/n)-(sumx/n)*(sumx/n)); // _a er hældningskoefficienten som skal ganges på alle volt værdierne 
            b1 = (sumy / n) - (a * (sumx / n));

            a = (float) a1; // Converts double to float. Is necessary because the database the values are defined as floats. 
            b = (float) b1;

            _calibration = new CalibrationValue(a,b); // sætter CalibrationsValue til _a
           Database.SaveCalibrateValue(_calibration); // kalder metoden SaveCalibration i Database gennem interface, og gemmer herved værdien for kalibreringen 

        }

        public CalibrationValue getCalibrateValue()
        {
            return _calibration;
        }

        public string updateCalibrateText()
        {
            return "Sidste kalibraring blev udført :" + today;
        }

    }
}
