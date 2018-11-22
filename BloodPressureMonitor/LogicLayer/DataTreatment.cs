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

        public static List<RawData> FullList;
        public static List<RawData> ShortRawList;
        public static List<RawData> DownsampledRawList;
        public static List<ConvertedData> ConvertedDataList;
        public static List<ConvertedData> GraphList;
      
        public static bool ShallStop { get; private set; }
        public static bool FilterShallStop { get; private set; }
        private static double Total { get; set; }
        private static double Average { get; set; }
        private static int Time { get; set; } = 1;


        public DataTreatment(BlockingCollection<RawData> collection)
        {
            _collection = collection;
            FullList = new List<RawData>();
            ConvertedDataList = new List<ConvertedData>();
            DataCollectorThread = new Thread(GetRawData);
            DownsampledRawList = new List<RawData>();
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
                if (DownsampledRawList.Count < 300)
                {
                    for (int i = FullList.Count - 5016; i < FullList.Count; i+=17) // 5000 samples equals 5 sec on 1000Hz // Flawed, what if theres less than 5000 samples??
                    {
                        for (int u = -8; u <= 8; u++) // Downsampling 17, 8 + 1 + 8.
                        {
                            Total = FullList[i + u].Voltage;
                        }

                        Average = Total / 17;
                        DownsampledRawList.Add(new RawData(Time, Average));
                        Time++;
                    }
                }

                if (DownsampledRawList.Count == 300) // 300 samples equals 5 sec on 60Hz
                {
                    for (int i = 0; i < 60; i++) // 60 samples is 1 sec on 60Hz
                    {
                        DownsampledRawList.RemoveAt(i);
                    }
                }

                Thread.Sleep(500); // Evt varier de 500
            }
        }

        public void MakeGraphList() // This needs redoing; its only taking the firs 5000 samples of Converted DataList, it needs to take the last
        {
            while (FilterController.ShallStop == true)
            {
                foreach (var sample in DownsampledRawList)
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
            return DownsampledRawList;
        }
    }
}
