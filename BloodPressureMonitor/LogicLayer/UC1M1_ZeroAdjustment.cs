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


        private IMeasure Measure;
        private BlockingCollection<RawData> _collection;
        public double ZeroAdjustmentValue { get; private set; }


        public UC1M1_ZeroAdjustment(BlockingCollection<RawData> collection, IMeasure measure)
        {
            _collection = collection;
            Measure = measure;

        }
       

        public double GetZeroAdjustmentValue()
        {
            

            Measure.StartMeasurement(); // start måling 

            ZeroAdjustmentValue = _collection.Take().Voltage; // sætter ZeroAdjustmentValue lig med det der måles

            if (ZeroAdjustmentValue != 90.00) // anden måde at tjekke det på?
            {
                Measure.StopMeasurement();// slutter måling 
            }
            return ZeroAdjustmentValue;


            // OBS skal give fejlmelding hvis det målete tryk overstiger normaltrykket med +%5. 
            // Men hvad er normaltrykket? 0???
        }






    }
}
