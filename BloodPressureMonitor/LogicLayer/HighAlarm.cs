using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class HighAlarm : IAlarmType 
    {
        // player reference oprettes
        SoundPlayer player = new SoundPlayer();

        public void GetFileSound()
        {
            // lydfil hentes
            player.SoundLocation = @"C: \Users\Celia\Documents\UNI\3 semester\Semesterprojekt 3(blodtrykmålesystem)\Github\BloodPressureMonitor\LogicLayer\bin\Debug\foghorn - daniel_simon.wav";
            // filnavnet : "foghorn - daniel_simon.wav" erstattes med filnavn fra DSB projekt 
        }

        public void RunAlarm()
        {
            player.Play();
            //Brugergrænseflade ændre udseende (tal for blodtryk bliver rød, knappen "kvitter alarm" bliver synlig)
        }

       
        public void StopAlarm()
        {
            if (runAlarm == false) // alarm stopper
            {
                // lydfilen stopper
                player.Stop();

                // brugergrænsefladen bliver normal igen (tal for blodtryk bliver grønne, knappen "kvitter alarm" usynliggøres)

            }



        }
    }
}
