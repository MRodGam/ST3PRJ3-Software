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
        private UC6S2_Calibrate calibrate = new UC6S2_Calibrate(); // reference til UC6S2_Calibrate
        private UC2M2_UC3M3_Measure measure;

        public CalibrateGUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // 30 mmHg måles
        {
            calibrate.AddVoltageValue(30);
            button2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e) //  kalibrer knappen
        {
            calibrate.DoCalibrateRegression(); // ved at trykke på knappen, dvs. den skal køre kalibreringen i logik-laget
            
        }

        private void button1_Click(object sender, EventArgs e) // 10 mmHg måles
        {
            calibrate.AddVoltageValue(10);
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e) // 50 mmHg måles
        {
            calibrate.AddVoltageValue(50);
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)// 75 mmHg måles
        {
            calibrate.AddVoltageValue(75);
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e) // 100 mmHg måles
        {
            calibrate.AddVoltageValue(100);
            button5.Enabled = false;
        }
    }
}
