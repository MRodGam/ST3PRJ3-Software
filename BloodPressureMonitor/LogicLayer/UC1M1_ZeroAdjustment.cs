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




        private BlockingCollection<RawData> _collection;
        public double ZeroAdjustmentValue { get; private set; }


        public UC1M1_ZeroAdjustment(BlockingCollection<RawData> collection)
        {
            _collection = collection;

        }
       

        public double GetZeroAdjustmentValue()
        {
            IMeasure measure = new UC2M2_UC3M3_Measure(); // ???


            measure.StartMeasurement(); // start måling 

            ZeroAdjustmentValue = _collection.Take().Voltage;

            if (ZeroAdjustmentValue != 90.00) // anden måde at tjekke det på?
            {
                measure.StopMeasurement();// slutter måling 
            }
            return ZeroAdjustmentValue;
        }






    }
}
