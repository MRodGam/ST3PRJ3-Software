﻿using System;
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
            player.SoundLocation = "Alarmtone\\alarmMedPause.wav"; 
        }

        public void RunAlarm()
        {
            player.SoundLocation = "Alarmtone\\alarmMedPause.wav";
            //lyden skal afspilles i et interval på 5 sekunder  
            player.PlayLooping();
            
            //Brugergrænseflade ændre udseende (tal for blodtryk bliver rød, knappen "kvitter alarm" bliver synlig)
        }

       


        public void StopAlarm()
        {
            //if (runAlarm == false) // alarm stopper
            //{

                // lydfilen stopper når denne metode kaldes
                player.Stop();

                // brugergrænsefladen bliver normal igen (tal for blodtryk bliver grønne, knappen "kvitter alarm" usynliggøres)

            //}



        }
    }
}
