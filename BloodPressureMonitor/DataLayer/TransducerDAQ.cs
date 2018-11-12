using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ST3PRJ3DAQ;
using Domain;

namespace DataLayer
{
    public class TransducerDAQ : IDAQ
    {
        public List<RawData> RawDataList { get; private set; }
        private static Thread measurementThread;
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
            ShallStop = false;
            measurementThread.Start();
        }

        public static void Stop()
        {
            ShallStop = true;
        }

        private List<RawData> GetRawData()
        {
            while (!ShallStop)
            {
                localDAQ.CollectData();



                List<RawData> ShortDataList = new List<RawData>();
                ShortDataList= localDAQ.CollectData();
                RawDataList.Add(ShortDataList);
            }
            
            
        }

       
    }
}
