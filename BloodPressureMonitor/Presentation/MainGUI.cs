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



        public filter()
        {
            InitializeComponent();
        }

        private void StartB_Click(object sender, EventArgs e)
        {
            // Is missing a method to do the start/stop eventhandler

            if (isMeasurementRunning== true)
            {
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
            }

            if (isMeasurementRunning == false)
            {
                StartB.BackColor = Color.ForestGreen;
                StartB = "START MÅLING";
            }
        }

        private void pauseB_Click(object sender, EventArgs e)
        {
            alarm.MuteAlarm();
            
        }
    }
}
