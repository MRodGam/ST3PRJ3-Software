using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataLayer;
using Presentation; // hvor hedder den ikke PresentationLayer som over i references ?
using Domain;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Blocking collections
            BlockingCollection<RawData> rawCollection = new BlockingCollection<RawData>();
            BlockingCollection<RawData> graphCollection = new BlockingCollection<RawData>();
            BlockingCollection<RawData> filterCollection = new BlockingCollection<RawData>();

            DAQ daq = new DAQ();

            // Interfaces
            IData data = new Database();
            IDAQ transducerdaq = new TransducerDAQ(daq, rawCollection);
            ILimits limits = new UC9S5_Limits();
            IAlarmType alarmType = new HighAlarm();


            // Domain classes
            ConvertAlgo convertAlgo = new ConvertAlgo();
            BloodPressureAlgo bloodpressureAlgo = new BloodPressureAlgo();

            DataTreatment dataTreatment = new DataTreatment(rawCollection,graphCollection,filterCollection, data,convertAlgo);
            IAlarm alarm = new UC5S1_Alarm(dataTreatment,limits, ,alarmType);
            IMeasure measure = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment, alarm);




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
        }
    }
}
