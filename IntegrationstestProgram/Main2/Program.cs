using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using PresentationLayer;
using DataLayer;
using LogicLayer;

namespace Main2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BlockingCollection<RawData> rawCollection = new BlockingCollection<RawData>();
            BlockingCollection<RawData> graphCollection = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            ConvertAlgo convertAlgo = new ConvertAlgo();

            IDAQ transducerdaq = new TransducerDAQ(daq, rawCollection);
            IData data = new Database();
            DataTreatment dataTreatment = new DataTreatment(rawCollection, graphCollection, convertAlgo, data);
            IMeasure measurement = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment);
            ICalibrate calibrate = new UC6S2_Calibrate(rawCollection, measurement);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CalibrateGUI calibrateGUI = new CalibrateGUI(calibrate, measurement);
            LoginToCalibrateGUI login = new LoginToCalibrateGUI(calibrateGUI);
            MainGUI gui = new MainGUI(dataTreatment,measurement,login);
            Application.Run(gui);
        }
    }
}
