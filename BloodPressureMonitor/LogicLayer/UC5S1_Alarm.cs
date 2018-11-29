using System;
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

        UC9S5_Limits Limits = new UC9S5_Limits();
        //IDataTreatment dataTreatment = new DataTreatment(); // hvad sker der her?

        private IAlarmType alarmType = new HighAlarm(); // korrekt at den er private ?

        //public bool IsAlarmActive { get; private set; } = false;
        public bool IsMeasureActive { get; set; }

        public UC5S1_Alarm(DataTreatment dataTreatment)
        {
            datatreatment_ = dataTreatment;
            
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
                if (datatreatment_.GetGraphList()[datatreatment_.GetGraphList().Count - 1].Pressure < Limits.SysLowerLimit ||
                    datatreatment_.GetGraphList()[datatreatment_.GetGraphList().Count - 1].Pressure > Limits.SysUpperLimit)
                {
                    alarmType.RunAlarm();
                    //IsAlarmActive = true;
                }

                // alarmen stopper hvis værdierne for blodtrykket ligger indenfor grænseværdierne 
                if (datatreatment_.GetGraphList()[datatreatment_.GetGraphList().Count - 1].Pressure >= Limits.SysLowerLimit  &&
                    datatreatment_.GetGraphList()[datatreatment_.GetGraphList().Count - 1].Pressure <= Limits.SysUpperLimit)
                {
                    alarmType.StopAlarm();
                    //IsAlarmActive = false;
                }

            }


        }

        public void MuteAlarm()// denne metode kaldes inde i eventhandleren for knappen kvitteralarm
        {
            //Timer counter = new Timer(180);
           
            //while (counter)
            //{
            //    alarmType.StopAlarm();
            //    IsAlarmActive = false;
            //}
            //alarmType.RunAlarm();
            //IsAlarmActive = true;


        }

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
