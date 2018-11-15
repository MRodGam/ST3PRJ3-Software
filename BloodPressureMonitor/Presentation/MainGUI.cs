using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using Domain;

namespace Presentation
{
    public partial class filter : Form
    {
        
        private IAlarm alarm; // denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;

        private BackgroundWorker muteAlarmWorker;
        
        public int Counter { get; private set; } = 0;

        public filter()
        {
            InitializeComponent();
            muteAlarmWorker = new BackgroundWorker();
            
        }

        private void StartB_Click(object sender, EventArgs e)
        {
            // Is missing a method to do the start/stop eventhandler
            Counter++;

            if (Counter % 2 == 0)
            {
                Measure.StartMeasurement();
                
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
            }
            if (Counter % 2 != 0)
            {
                Measure.StopMeasurement();
                
                StartB.BackColor = Color.ForestGreen;
                StartB.Text = "START MÅLING";
            }


           
        }

        private void pauseB_Click(object sender, EventArgs e)
        {
            //BackgroundWorker ??
            // hvis alarmen er aktiv skal knappen være synlig 
            if (alarm.GetIsAlarmActive() == true)
            {
                pauseB.Visible = true;
            }

            alarm.MuteAlarm(); // kalder metoden MuteAlarm inde i UC5S1_Alarm

            
            // hvis alarmen ikke er aktiv skal knappen være usynlig 
            if (alarm.GetIsAlarmActive() == false)
            {
                pauseB.Visible = false;
            }

        }
    }
}
