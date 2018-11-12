﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public class DataTreatment : IDataTreatment
    {
        private BlockingCollection<RawData> _collection;
        public List<RawData> TreatmentList;

        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            TreatmentList = new List<RawData>();
        }
        public double GetConvertedData()
        {
            // Return the converted data List
        }

        public void TreatData()
        {
            while (true)
            {
                for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                {
                    TreatmentList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                } 

                // DataTreatment code
                // This code should use the conversion algorithm written in a seperate class
                // Put into a list
            }
        }
    }
}
