using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC2M2_UC3M3_Measure : IMeasure
    {
        private IDAQ Daq;
        private DataTreatment dataTreatment;
        // private UC5S1_Alarm AlarmController;
        
        public UC2M2_UC3M3_Measure(IDAQ actualDaq, DataTreatment _dataTreatment)
        {
            Daq = actualDaq;
            dataTreatment = _dataTreatment;
            // AlarmController = alarmController;
        }

        public void StartMeasurement()
        {
            Daq.Start();
            dataTreatment.StartGraphData();
            // AlarmController.alarmThread.Set(); // Alarm klassen starter
            // AlarmController.IsMeasureActive = true;
        }

        public void StopMeasurement()
        {
            Daq.Stop();
            dataTreatment.StopGraphData();
            // AlarmController.IsMeasureActive = false;
        }
    }
}
