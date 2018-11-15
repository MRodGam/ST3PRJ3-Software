using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataLayer;
using Domain;

namespace DAQTestpogram
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<RawData> rawData = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            IDAQ transducerdaq = new TransducerDAQ(daq, rawData);
            UC2M2_UC3M3_Measure newMeasurement = new UC2M2_UC3M3_Measure(transducerdaq);
            DataTreatment dataTreatment = new DataTreatment(rawData);


            newMeasurement.StartMeasurement();
            dataTreatment.ShowData();

            Console.ReadKey();
        }
    }
}
