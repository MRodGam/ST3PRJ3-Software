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
        private static Thread DataCollectorThread;
        private static Thread ShortRawThread;

        public static List<RawData> FullList;
        public static List<RawData> ShortRawList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;

        public static bool ShallStop { get; private set; }
        public static bool FilterShallStop { get; private set; }


        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            FullList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            DataCollectorThread = new Thread(GetRawData);
        }

        public void StartGraph()
        {
            ShallStop = false;
            DataCollectorThread.Start();
        }

        public void StopGraph()
        {
            ShallStop = true;
        }

        public void GetRawData()
        {
             while (!ShallStop)
             {
                 for (int i = 0; i < 1000; i++) // 1000 being the amount of samples we want to process at a time. We NEED make sure this is the right number
                 {
                     FullList.Add(_collection.Take()); // Should add 1000 samples into the treatment list.
                 }
             }
        }

        public static void MakeShortRawList()
        {
            while (!ShallStop)
            {
                for (int i = FullList.Count - 5000; i < FullList.Count; i++) // Nedsampling?
                {
                    PreDownsampledList.Add(FullList[i]);
                }

                for (int i = 0; i < 5000 && i < FullList.Count; i++)
                {
                    ShortRawList.Add(FullList[i]); // Skal ændres, fordi den bliver ved med at tage de første samples i treatmentlist, den skal tage de sidste
                }

                if (ShortRawList.Count == 5000)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        ShortRawList.RemoveAt(i);
                    }
                }

                Thread.Sleep(500); // Evt varier de 500
            }
        }

        public void MakeGraphList() // This needs redoing; its only taking the firs 5000 samples of Converted DataList, it needs to take the last
        {
            while (FilterController.ShallStop == true)
            {
                foreach (var sample in ShortRawList)
                {
                    GraphList = ConvertAlgo(sample.Second, sample.Voltage);
                }
            }
        }

        public List<ConvertedData> GetGraphList() // Skal returnere det nedsamplede converterede data
        {
           return GraphList;
        }

        public List<RawData> GetFilterList() // Skal returnere det nedsamplede rådata
        {
            return ShortRawList;
        }
    }
}
