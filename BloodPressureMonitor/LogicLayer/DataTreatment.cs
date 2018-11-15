using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer // Consumer
{
    public class DataTreatment : IDataTreatment
    {
        private BlockingCollection<RawData> _collection;
        public List<RawData> TreatmentList;
        public List<ConvertedData> ConvertedDataList;


        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            TreatmentList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
        }
        public List<ConvertedData> GetConvertedData()
        {
             while (true)
             {
                 for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                 {
                     TreatmentList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                 }

                 foreach (var obj in TreatmentList)
                 {
                     ConvertAlgo.ConvertData(obj.Second,obj.Voltage);
                 }
             }

        }

        public List<RawData> GetRawData()
        {
            return TreatmentList;
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
                // This code should use the conversion algorithm written in a separate class
                // Put into a list
            }
        }
    }
}
