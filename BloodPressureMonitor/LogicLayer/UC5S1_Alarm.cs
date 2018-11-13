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

        private bool runAlarm = false;
        private bool muteAlarm = false;
        UC9S5_Limits Limits = new UC9S5_Limits();
        DataTreatment dataTreatment = new DataTreatment(); // hvad sker der her?

        private IAlarmType alarmType; // korrekt at den er private ?
        


      public void ControlAlarm() // metode der kontrollere alarmen
        {

            // hvis blodtryksværdi overskrider grænseværdier
            if (dataTreatment.GetConvertedData() < Limits.getLowerLimit() || dataTreatment.GetConvertedData() > Limits.getUpperLimit() )
            {
                alarmType.RunAlarm();
            }
            else if () // hvis knappen "Kvitter alarm" er trykket på, eller en variable bliver sat true inde i eventhandleren 
            {
                alarmType.MuteAlarm();
            }
            else
            alarmType.StopAlarm();
        }

        

       
    }
}
