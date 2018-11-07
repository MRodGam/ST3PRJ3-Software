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
       

        public TransducerDAQ()
        {
            RawDataList = new List<RawData>();
            measurementThread = new Thread(GetRawData);
        }
        public static void Start()
        {
            measurementThread.Start();
        }

        public static void Stop()
        {
            ShallStop = true;
        }

        private void GetRawData()
        {
            DAQ daq = new DAQ();
            while (!ShallStop)
            {
                while (true)
                {
                    DAQ.GetRawData();
                }
            }
            
            RawDataList = DAQ.GetRawData();
        }

       
    }
}
