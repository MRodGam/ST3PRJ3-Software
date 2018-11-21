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
        private ICalibrate calibrate; // reference til ICalibrate
        private IMeasure measure; // reference til ICalibrate

        private LoginToCalibrateGUI loginToCalibrateRef = new LoginToCalibrateGUI(); // er det OK at jeg opretter en new her??

        

        public CalibrateGUI(ICalibrate calibrate, IMeasure measure)
        {
            InitializeComponent();

            this.Visible = false; // Vinduet skjules til en start, og kommer kun frem hvis login = true (se koden nedenunder)


            loginToCalibrateRef.ShowDialog();

            if (loginToCalibrateRef.LoginOK == true)
            {
                this.Visible = true;
            }
            else
                this.Close(); // denne skal være der for at man ikke bare kan lukke login vinduet og så vil hovedvinduet komme frem, den vil nu lukke
        }

        private void button2_Click(object sender, EventArgs e) // 30 mmHg måles
        {
            calibrate.AddVoltageValue(30);
            button2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e) //  kalibrer knappen
        {
            calibrate.DoCalibrateRegression(); // Kører metoden DoCalibration i logiklaget
            
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
