﻿using System;
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


        private IDAQ _daq;
        private BlockingCollection<RawData> _collection;
        public double ZeroAdjustmentValue { get; private set; } = -11; // -11 fordi så kan den ikke gå ind i if-sætning hvis ikke den har lavet en måling og derved ændret værdien
        public bool IsZeroAdjustDone { get; private set; } = false;
        private double TotalValue=0;

        //public int IsMeasureRight { set; get; } = 0;


        public UC1M1_ZeroAdjustment(BlockingCollection<RawData> collection, IDAQ daq)
        {
            _collection = collection;
            _daq = daq;

        }
       

        public double GetZeroAdjustmentValue()
        {
            //IsMeasureRight = 0;
            double normalUpper = 1.2 * 1.05; // normalværdie for volt + 5 procent 
            double normalUnder = 1.2 * 0.95; // normalværdie for volt - 5 procent 

            _daq.Start(); // start måling 

            for (int i = 0; i < 5; i++) // tager fem målinger
            {
                TotalValue = _collection.Take().Voltage; // sætter ZeroAdjustmentValue lig med det der måles
            }

            ZeroAdjustmentValue = TotalValue / 5;

            if (ZeroAdjustmentValue > -10) // skrives på anden måde måske?
            {
                _daq.Stop();// slutter måling 
                IsZeroAdjustDone = true;
            }

            return ZeroAdjustmentValue;


            // OBS skal give fejlmelding hvis det målete tryk overstiger normaltrykket med +%5. 
            // Men hvad er normaltrykket? 0???

            //if (ZeroAdjustmentValue <= normalUpper && normalUnder <= ZeroAdjustmentValue) // hvis værdien varierer mere end +-5%
            //{
            //    return ZeroAdjustmentValue;

            //}
            //else return IsMeasureRight = 1;

        }


        public double ZeroAdjust(double rawData)
        {
            return rawData - ZeroAdjustmentValue;
        }






    }
}
