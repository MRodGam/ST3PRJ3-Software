using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using LogicLayer;
using PresentationLayer;
using DataLayer;
using System.Windows.;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<RawData> rawCollection = new BlockingCollection<RawData>();
            BlockingCollection<RawData> graphCollection = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            ConvertAlgo convertAlgo = new ConvertAlgo();

            IDAQ transducerdaq = new TransducerDAQ(daq, rawCollection);
            DataTreatment dataTreatment = new DataTreatment(rawCollection,graphCollection,convertAlgo,);
            IMeasure measurement = new UC2M2_UC3M3_Measure(transducerdaq,dataTreatment);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI(dataTreatment));

        }
    }
}
