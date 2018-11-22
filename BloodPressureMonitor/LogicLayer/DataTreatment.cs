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
        private UC7S3_Filter FilterController;

        private BlockingCollection<RawData> _collection;
        private static Thread GraphListThread;
        private static Thread FilterListThread;

        public static List<RawData> TreatmentList;
        public static List<RawData> FilterList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;

        public static bool ShallStop { get; private set; }
        public static bool FilterShallStop { get; private set; }


        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            TreatmentList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            GraphListThread = new Thread(MakeGraphList);
            FilterListThread = new Thread(MakeFilterList);
        }

        public List<RawData> GetDownSampledData()
        {
            while (true)
            {
                for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                {
                    TreatmentList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                }
            }
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
                     // Should do a downsampling here
                     ConvertedDataList.Add(ConvertedDataSample);
                }
             }
        }


        public void StartGraph()
        {
            ShallStop = false;
            GraphListThread.Start();
        }

        public void StopGraph()
        {
            ShallStop = true;
        }

        public static void MakeGraphList() // This needs redoing; its only taking the firs 5000 samples of Converted DataList, it needs to take the last
        {
            
        }

        public List<ConvertedData> GetGraphList() // Skal returnere det nedsamplede converterede data
        {
           return GraphList;
        }

        public static void MakeFilterList()
        {
             for (int i = 0; i < 5000 && i < TreatmentList.Count; i++)  // Skal ændres, fordi den bliver ved med at tage de første samples i treatmentlist, den skal tage de sidste
             {
                 FilterList.Add(TreatmentList[i]);
             }

             if (FilterList.Count == 5000)
             {
                 for (int i = 0; i < 1000; i++)
                 {
                     FilterList.RemoveAt(i);
                 }
             }

             Thread.Sleep(500); // Evt varier de 500
        }

        public List<RawData> GetFilterList() // Skal returnere det nedsamplede rådata
        {
            if (FilterController.ShallStop == false)
            {
                FilterListThread.Start();
            }
            return FilterList;
        }
    }
}
