using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer // Consumer
{
    public class DataTreatment : IDataTreatment
    {
        private ConvertAlgo ConvertAlgo;

        private BlockingCollection<RawData> _collection;
        private static Thread GraphThread;

        public List<RawData> TreatmentList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;

        public bool ShallStop { get; private set; }

        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            TreatmentList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            GraphThread = new Thread(MakeGraphList);
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

        public void StartGraph()
        {
            ShallStop = false;
        }

        public void StopGraph()
        {
            ShallStop = true;
        }

        public static void MakeGraphList()
        {
            while (!TransducerDAQ.ShallStop)
            {
                for (int i = 0; i < 5000 && i < ConvertedDataList.Count; i++)
                {
                    GraphList.Add(ConvertedDataList[i]);
                }

                if (GraphList.Count == 5000)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        GraphList.RemoveAt(i);
                    }
                }

                Thread.Sleep(500); // Evt varier de 500
            }
        }

        public List<ConvertedData> GetGraphList()
        {
           return GraphList;
        }
    }
}
