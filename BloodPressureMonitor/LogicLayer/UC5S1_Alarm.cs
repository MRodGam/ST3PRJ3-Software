using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC5S1_Alarm : IAlarm
    {

        private bool runAlarm = false;
        private bool muteAlarm = false;
        UC9S5_Limits Limits = new UC9S5_Limits();
        UC2M2_UC3M3_Measure Measure = new UC2M2_UC3M3_Measure();


        // lydfil hentes
        

        public void ControlAlarm() // metode der kontrollere alarmen
        {
            // hvis blodtryksværdi overskrider grænseværdier
            if (Measure.GetMeasure() < Limits.getLowerLimit() || Measure.GetMeasure() > Limits.getUpperLimit() )
            {
                runAlarm = true;
            }
            else if () // hvis knappen "Kvitter alarm" er trykket på
            {
                muteAlarm = true;
            }
            else
            runAlarm = false;
        }

        public void StartAlarm()
        {
            if (runAlarm == true)
            {
                // alarm starter: 
                //lydfil afspilles,
                //Brugergrænseflade ændre udseende (tal for blodtryk bliver rød, knappen "kvitter alarm" bliver synlig)


            }
        }

        public void MuteAlarm()
        {
            if (muteAlarm==true)
            {
                // Knappen "Kvitter alarm" usynliggøres
                // lydfilen stoppes
            }
        }

        public void StopAlarm()
        {
            if (runAlarm == false)
            {
                // lydfilen stoppe
                // brugergrænsefladen bliver normal igen (tal for blodtryk bliver grønne, knappen "kvitter alarm" usynliggøres)

            }



        }
    }
}
