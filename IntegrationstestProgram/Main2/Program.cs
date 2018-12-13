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
            BlockingCollection<RawData> calibrationCollection = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            ConvertAlgo convertAlgo = new ConvertAlgo();

            IDAQ transducerdaq = new TransducerDAQ(daq, rawCollection, calibrationCollection);
            IData data = new Database();
            DataTreatment dataTreatment = new DataTreatment(rawCollection, graphCollection, convertAlgo, data);
            IMeasure measurement = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment);
            ICalibrate calibrate = new UC6S2_Calibrate(calibrationCollection, transducerdaq);
            IZeroAdjustment zero = new UC1M1_ZeroAdjustment(calibrationCollection,transducerdaq);
            UC1M1_ZeroAdjustment uc1 = new UC1M1_ZeroAdjustment(calibrationCollection,transducerdaq);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ZeroAdjustmentGUI zeroAdjustment = new ZeroAdjustmentGUI(zero,uc1);
            CalibrateGUI calibrateGUI = new CalibrateGUI(calibrate, measurement);
            LoginToCalibrateGUI login = new LoginToCalibrateGUI(calibrateGUI);
            MainGUI gui = new MainGUI(dataTreatment,measurement,login,zeroAdjustment);
            Application.Run(gui);
        }
    }
}
