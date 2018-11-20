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

namespace Presentation
{
    public partial class CalibrateGUI : Form
    {
        private UC6S2_Calibrate calibrate; // reference til UC6S2_Calibrate
        private UC2M2_UC3M3_Measure measure;

        public CalibrateGUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            measure = new UC2M2_UC3M3_Measure();
            calibrate = new UC6S2_Calibrate(); // der skal stå noget i parameteren 

            measure.StartMeasurement(); // start måling -> skal stoppe igen efter den har lavet et take?

            calibrate.DoCalibrateAlgo(); // ved at trykke på OK, dvs. den skal køre algoritmen, så kaldes metoden DoCalibrateAlgo i Controller klassen for Calibrate

            if (expr)
            {
                
            }
            measure.StopMeasurement();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
