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
            BlockingCollection<double> rawCollection = new BlockingCollection<double>();
            BlockingCollection<double> graphCollection = new BlockingCollection<double>();
            BlockingCollection<double> calibrationCollection = new BlockingCollection<double>();
            BlockingCollection<double> alarmCollection = new BlockingCollection<double>();
            BlockingCollection<double> filterCollection = new BlockingCollection<double>();

            DAQ daq = new DAQ();
            ConvertAlgo convertAlgo = new ConvertAlgo();
            BloodPressureAlgo bpAlgo = new BloodPressureAlgo();
            PulseAlgo pulseAlgo = new PulseAlgo();

            IDAQ transducerdaq = new TransducerDAQ(daq, rawCollection, calibrationCollection);
            IData data = new Database();
            IAlarmType alarmType = new HighAlarm();
            ILimits limits = new UC9S5_Limits();


            IAlarm alarm = new UC5S1_Alarm(alarmCollection,limits, alarmType, bpAlgo);
            IFilter filter = new UC7S3_Filter(filterCollection, data, convertAlgo);
            UC1M1_ZeroAdjustment uc1 = new UC1M1_ZeroAdjustment(calibrationCollection, transducerdaq);
            DataTreatment dataTreatment = new DataTreatment(rawCollection, graphCollection, filterCollection, alarmCollection, convertAlgo, data, alarm, uc1);
            IMeasure measurement = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment,alarm, filter);
            ICalibrate calibrate = new UC6S2_Calibrate(calibrationCollection, transducerdaq,data);
            IZeroAdjustment zero = new UC1M1_ZeroAdjustment(calibrationCollection,transducerdaq);
            IPulse pulse = new UC8S4_Pulse(dataTreatment,pulseAlgo);
            ISave save = new UC4M4_SaveData(data, dataTreatment);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ZeroAdjustmentGUI zeroAdjustment = new ZeroAdjustmentGUI(zero);
            CalibrateGUI calibrateGUI = new CalibrateGUI(calibrate, measurement);
            LoginToCalibrateGUI login = new LoginToCalibrateGUI(calibrateGUI);
            SaveDataGUI saveGUI = new SaveDataGUI(save);
            ChangeLimitsGUI limitsGUI = new ChangeLimitsGUI(limits);
            MainGUI gui = new MainGUI(dataTreatment, measurement, login, zeroAdjustment,alarm, pulse,bpAlgo, filter, saveGUI, limitsGUI, calibrateGUI);
            Application.Run(gui);
        }
    }
}
