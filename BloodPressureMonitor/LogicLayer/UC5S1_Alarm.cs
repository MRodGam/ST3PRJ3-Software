using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    class UC5S1_Alarm : IAlarm
    {

        UC9S5_Limits Limits = new UC9S5_Limits();
        DataTreatment dataTreatment = new DataTreatment(); // hvad sker der her?

        private IAlarmType alarmType; // korrekt at den er private ?
        public bool IsAlarmActive { get; private set; } = false;
        
        public void PlayAlarm() // metode der kontrollere alarmen
        {

            // hvis blodtryksværdi overskrider grænseværdier
            if (dataTreatment.GetConvertedData() < Limits.getLowerLimit() ||
                dataTreatment.GetConvertedData() > Limits.getUpperLimit())
            {
                alarmType.RunAlarm();
                IsAlarmActive = true;
            }

        }

        public void MuteAlarm()// denne metode kaldes inde i eventhandleren for knappen kvitteralarm
        {
            alarmType.MuteAlarm();

        } 

        public void StopAlarm()
        {
            // alarmen stoppe hvis værdierne for blodtrykket ligger indenfor grænseværdierne 
            if (dataTreatment.GetConvertedData() >= Limits.getLowerLimit() &&
                dataTreatment.GetConvertedData() <= Limits.getUpperLimit())
            {
                alarmType.StopAlarm();
                IsAlarmActive = false;
            }
            
            
            
        }
            
        


        

       
    }
}
