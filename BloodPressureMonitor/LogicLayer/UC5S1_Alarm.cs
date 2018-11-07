using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC5S1_Alarm : IAlarm
    {

        private bool runAlarm = false;
        private bool muteAlarm = false;
        UC9S5_Limits Limits = new UC9S5_Limits();
        DataTreatment dataTreatment = new DataTreatment();
        


        // player klassen oprettes
        SoundPlayer player = new SoundPlayer();

        public void GetFileSound()
        {
            // lydfil hentes
            player.SoundLocation = @"C: \Users\Celia\Documents\UNI\3 semester\Semesterprojekt 3(blodtrykmålesystem)\Github\BloodPressureMonitor\LogicLayer\bin\Debug\foghorn - daniel_simon.wav";
            // filnavnet : "foghorn - daniel_simon.wav" erstattes med filnavn fra DSB projekt 
        }


        public void ControlAlarm() // metode der kontrollere alarmen
        {
            

            // hvis blodtryksværdi overskrider grænseværdier
            if (dataTreatment.GetConvertedData() < Limits.getLowerLimit() || dataTreatment.GetConvertedData() > Limits.getUpperLimit() )
            {
                runAlarm = true;
            }
            else if () // hvis knappen "Kvitter alarm" er trykket på, eller en variable bliver sat true inde i eventhandleren 
            {
                muteAlarm = true;
            }
            else
            runAlarm = false;
        }

        public void StartAlarm()
        {
            if (runAlarm == true) // alarm starter
            {
                // lydfil afspilles,
                player.Play();
              
                
                //Brugergrænseflade ændre udseende (tal for blodtryk bliver rød, knappen "kvitter alarm" bliver synlig)

            }
        }

        public void MuteAlarm()
        {
            if (muteAlarm==true) // alarm pauser
            {
                // Knappen "Kvitter alarm" usynliggøres
                // symbol på brugergrænsefladens mainGUI synliggøres -> evt. i eventhandleren for knappen "Kvitter alarm"

                // lydfilen stoppes / pauses
                player.Stop();
                // alarm starter igen efter 180 sekunder ???
                player.Play();

            }
        }

        public void StopAlarm()
        {
            if (runAlarm == false) // alarm stopper
            {
                // lydfilen stoppe
                player.Stop();

                // brugergrænsefladen bliver normal igen (tal for blodtryk bliver grønne, knappen "kvitter alarm" usynliggøres)

            }



        }
    }
}
