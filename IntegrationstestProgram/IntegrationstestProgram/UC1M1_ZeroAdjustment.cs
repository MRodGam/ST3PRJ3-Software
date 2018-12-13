using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC1M1_ZeroAdjustment : IZeroAdjustment
    {
        // når man trykke på nulpunktsjusterknappen skal målingen starte, og der tages en volt måling af collection
        // det den måler skal den returner
        // det er meningen man blot skal måle ude i atmosfæren
        public bool IsMeasureRight { get; private set; } = false;

        private IDAQ _daq;
        private BlockingCollection<double> _calibrationCollection;
        public double ZeroAdjustmentValue { get; private set; } = -11; // -11 fordi så kan den ikke gå ind i if-sætning hvis ikke den har lavet en måling og derved ændret værdien
        public bool IsZeroAdjustDone { get; private set; } = false;
        private double TotalValue=0;

        //public int IsMeasureRight { set; get; } = 0;


        public UC1M1_ZeroAdjustment(BlockingCollection<double> calibrationCollection, IDAQ daq)
        {
            _calibrationCollection = calibrationCollection;
            _daq = daq;
            IsZeroAdjustDone = false;
        }
       

        public double GetZeroAdjustmentValue()
        {
            IsMeasureRight = false; // sættes til false til at starte med

            double normalUpper = -1.9*1.05; // normalværdie for volt + 5 procent 
            double normalUnder = -1.9 * 0.95; // normalværdie for volt - 5 procent 
            ZeroAdjustmentValue = 0;

            _daq.StartCalibration(); // start måling 

            for (int i = 0; i < 1000; i++) // tager fem målinger
            {
                TotalValue += _calibrationCollection.Take(); // sætter ZeroAdjustmentValue lig med det der måles
            }
            ZeroAdjustmentValue = TotalValue / 1000;

            //if (ZeroAdjustmentValue > -10) // skrives på anden måde måske?
            //{
            //    IsZeroAdjustDone = true;
            //}

            


            // OBS skal give fejlmelding hvis det målete tryk overstiger normaltrykket med +%5. 
            
            if (ZeroAdjustmentValue <= normalUpper && normalUnder <= ZeroAdjustmentValue) // hvis værdien varierer mere end +-5%
            {
                IsMeasureRight = true;

            }
            else IsMeasureRight = false;

            return ZeroAdjustmentValue;

        }


        public double ZeroAdjust(double rawData)
        {
            return rawData - ZeroAdjustmentValue;
        }

        public bool IsMeasureRigth()
        {
            return IsMeasureRight;
        }






    }
}
