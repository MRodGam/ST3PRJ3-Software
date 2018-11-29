using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private UC5S1_Alarm AlarmController;
        private BloodPressureAlgo BloodPressureAlgo;
        private Database Database;
        

        public double CaliValue { get; private set; }
        
       
        public UC2M2_UC3M3_Measure(IDAQ actualDaq, DataTreatment _dataTreatment, UC5S1_Alarm alarmController, BloodPressureAlgo bloodPressureAlgo, Database database)
        {
            Daq = actualDaq;
            dataTreatment = _dataTreatment;
            AlarmController = alarmController;
            BloodPressureAlgo = bloodPressureAlgo;
            Database = database;
            
        }

        public void StartMeasurement()
        {
            
            CaliValue = Database.GetCalibration(); // henter værdien for kalibering i databasen og sætter lig med CaliValue 
            

            Daq.Start();
            dataTreatment.StartGraphData();
            AlarmController.alarmThread.Set(); // Alarm klassen starter
            AlarmController.IsMeasureActive = true;
            
        }

        public void StopMeasurement()
        {
            Daq.Stop();
            dataTreatment.StopGraphData();
            AlarmController.IsMeasureActive = false;

        }
    }
}
