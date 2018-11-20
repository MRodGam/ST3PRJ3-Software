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
        public ConvertAlgo ConvertAlgo;
        public List<ConvertedData> GraphList;


        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            TreatmentList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
        }
        public double GetConvertedData()
        {
             while (true)
             {
                 for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                 {
                     TreatmentList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                 }

                 foreach (var obj in TreatmentList)
                 {
                     ConvertedData ConvertedDataSample = ConvertAlgo.ConvertData(obj.Second, obj.Voltage);
                     ConvertedDataList.Add(ConvertedDataSample);
                }
             }

        }

        public List<ConvertedData> GetGraphList()
        {
             for (int i = 0; i < 5000; i++)
             {
                 GraphList.Add(ConvertedDataList[i]);
             }

             if (GraphList.Count == 5000)
             {
                 for (int i = 0; i < 1000; i++)
                 {
                     GraphList.RemoveAt(i);
                 }

                 for (int i = 0; i < 4000; i++)
                 {
                     int counter = 1000;
                     GraphList[i] = GraphList[counter];
                     counter++;
                 }
             }

            return GraphList;
        }
    }
}
