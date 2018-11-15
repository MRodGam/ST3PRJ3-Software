using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public class TransducerDAQ : IDAQ // Producer
    {
        public List<RawData> RawDataList { get; private set; }
        public List<RawData> CollectedData;
        private static Thread measurementThread;
        public static bool ShallStop { get; private set; }
        public DAQ localDAQ;
        private BlockingCollection<RawData> _collection;


        public TransducerDAQ(DAQ actualDAQ, BlockingCollection<RawData> collection) // Takes a DAQ parameter, so that we're sure it will be conected to thesae DAQ as the remaining classes when they are initiated
        {
            localDAQ = actualDAQ;
            _collection = collection;
            RawDataList = new List<RawData>();
            measurementThread = new Thread(GetRawData);
        }


        public void Start()
        {
            measurementThread.Start(); //
            ShallStop = false; // Sets  ShallStop back to false. 
        }


        public void Stop()
        {
            ShallStop = true; // Stops thread. 
        }

        public void GetRawData() // This method is used exclusively by the measuring thread 
        {
            while (!ShallStop)
            {
                localDAQ.CollectData(); // Starts the data collection
                CollectedData = localDAQ.GetCollectedRawData();

                foreach (var obj in CollectedData)// Transfers content measured from the DAQ to the collection
                {
                    _collection.Add(obj);
                }

                //foreach (var obj in localDAQ.GetCollectedRawData())// Transfers content measured from the DAQ to the collection
                //{
                //    _collection.Add(obj);
                //}
            }
        }
    }
}
