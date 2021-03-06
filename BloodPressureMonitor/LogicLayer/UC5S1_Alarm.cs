﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DataLayer;
using Domain;


namespace LogicLayer
{
    public class UC5S1_Alarm : IAlarm
    {
        public DataTreatment datatreatment_;
        public AutoResetEvent alarmThread { get; set; } // tråd som alarm klassen kører på


        private ILimits Limits;
        //private BloodPressure BloodPressure;
        private IAlarmType AlarmType; // typen vælges i parameteren når man opretter klassen UC5S1_Alarm
        private BloodPressureAlgo BloodpressureAlgoRef;

        //public bool IsAlarmActive { get; private set; } = false;
        public bool IsMeasureActive { get; set; } // sættes i UC2M2_UCM3_Measure
        public bool IsAlarmRunning { get; private set; } = false;

        public UC5S1_Alarm(DataTreatment dataTreatment,ILimits limits, BloodPressure bloodPressure, IAlarmType alarmType, BloodPressureAlgo bloodpressureAlgoRef )
        {
            datatreatment_ = dataTreatment;
            Limits = limits;
            //BloodPressure = bloodPressure;
            AlarmType = alarmType;
            BloodpressureAlgoRef = bloodpressureAlgoRef;

        }

        

        //public bool GetIsAlarmActive()
        //{
        //    return IsAlarmActive;
        //}
        
        public void ControlAlarm() // metode der kontrollere alarmen
        {
            alarmThread.WaitOne(); // kører i tråd, således den hele tiden tjekker om alarmen skal starte 

            while (IsMeasureActive)
            {

                // hvis blodtryksværdi overskrider grænseværdier
                // henter systolisk værdi i Domæne klassen "BloodPressure" og tjekker i forhold til limits-værdierne 
                if (BloodpressureAlgoRef.SysBP < Limits.GetLowerLimit() ||
                    BloodpressureAlgoRef.SysBP > Limits.GetUpperLimit() )
                {
                    AlarmType.RunAlarm();
                    IsAlarmRunning = true;
                }

                // alarmen stopper hvis værdierne for blodtrykket ligger indenfor grænseværdierne 
                if (BloodpressureAlgoRef.SysBP >= Limits.GetLowerLimit() &&
                    BloodpressureAlgoRef.SysBP <= Limits.GetUpperLimit())
                {
                    AlarmType.StopAlarm();
                    IsAlarmRunning = false;
                }

            }
            

        }

        public bool GetIsAlarmRunning()
        {
            return IsAlarmRunning;
        }

        //public void MuteAlarm()// denne metode kaldes inde i eventhandleren for knappen kvitteralarm
        //{
        //    //Timer counter = new Timer(180);
           
        //    //while (counter)
        //    //{
        //    //    alarmType.StopAlarm();
        //    //    IsAlarmActive = false;
        //    //}
        //    //alarmType.RunAlarm();
        //    //IsAlarmActive = true;


        //}

        //public void MuteAlarm()
        //{

            

        
        //    if (muteAlarm == true) 
        //    {
        //        // Knappen "Kvitter alarm" usynliggøres
        //        // symbol på brugergrænsefladens mainGUI synliggøres -> evt. i eventhandleren for knappen "Kvitter alarm"

        //        // lydfilen stoppes / pauses
        //        player.Stop();

        //        // alarm starter igen efter 180 sekunder ???
        //        player.Play();

        //    }
        //}

        //public void StopAlarm()
        //{
           

           
            
        //}


            
        


        

       
    }
}
