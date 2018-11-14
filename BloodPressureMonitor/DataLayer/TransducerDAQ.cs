using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public class TransducerDAQ : IDAQ // This is no good, have Lars look at it with you
    {
        public List<RawData> RawDataList { get; private set; }
        private static Thread measurementThread; // Should this thread be ma
        public static bool ShallStop { get; private set; }
        public DAQ localDAQ;
       

        public TransducerDAQ(DAQ actualDAQ)
        {
            localDAQ = actualDAQ;
            RawDataList = new List<RawData>();
            measurementThread = new Thread(GetRawData);
        }


        public static void Start()
        {
            measurementThread.Start(); //
            ShallStop = false; // Sets  ShallStop back to false. 
        }


        public static void Stop()
        {
            ShallStop = true;
        }

        private void GetRawData() // This method is used exclusively by the measuring thread 
        {
            while (!ShallStop)
            { 
                localDAQ.CollectData();

                List<RawData> ShortDataList = new List<RawData>();
                ShortDataList= localDAQ.CollectData();
                RawDataList.AddRange(ShortDataList);
            }
        }

       
    }
}
