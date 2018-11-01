using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC5S1_Alarm : IAlarm
    {

        private bool RunAlarm = false;


        // lydfil hentes
        // metode der starter alarm

        public void ControlAlarm()
        {
            // hvis blodtryksværdi overskrider grænseværdier

            RunAlarm = true;

            // if else
            RunAlarm = false;
        }

        public void StartAlarm()
        {
            if (RunAlarm == true)
            {
                // alarm starter: 
                //lydfil afspilles,
                //Brugergrænseflade ændre udseende (tal for blodtryk bliver rød, knappen "kvitter alarm" bliver synlig)


            }
        }

        public void muteAlarm()
        {
            //if (Knappen kvitter alarm er trykket på )
            {
                // Knappen "Kvitter alarm" usynliggøres
                // lydfilen stoppes
            }
        }

        public void StopAlarm()
        {
            if (RunAlarm == false)
            {
                // lydfilen stoppe
                // brugergrænsefladen bliver normal igen (tal for blodtryk bliver grønne, knappen "kvitter alarm" usynliggøres)

            }



        }
    }
}
