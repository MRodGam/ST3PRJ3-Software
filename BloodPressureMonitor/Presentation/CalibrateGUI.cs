using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using LogicLayer;

namespace Presentation
{
    public partial class CalibrateGUI : Form
    {
        private ICalibrate calibrate; // reference til ICalibrate
        private IMeasure measure; // reference til ICalibrate
        private MainGUI MainGuiRef;
        private CalibrationValue calibrationValue;
        

        private LoginToCalibrateGUI LoginToCalibrateRef; // er det OK at jeg opretter en new her??

        public bool IsCalibrateDone { get; set; } = false;

        

        public CalibrateGUI(ICalibrate calibrate, IMeasure measure, LoginToCalibrateGUI loginToCalibrateRef, MainGUI mainGui, CalibrationValue caliValue)
        {
            InitializeComponent();
            LoginToCalibrateRef = loginToCalibrateRef;
            MainGuiRef = mainGui;
            calibrationValue = caliValue;

            this.Visible = false; // Vinduet skjules til en start, og kommer kun frem hvis login = true (se koden nedenunder)


            LoginToCalibrateRef.ShowDialog();

            if (LoginToCalibrateRef.LoginOK == true)
            {
                this.Visible = true;
            }
            else
                this.Close(); // denne skal være der for at man ikke bare kan lukke login vinduet og så vil hovedvinduet komme frem, den vil nu lukke
        }

        private void button1_Click(object sender, EventArgs e) // 10 mmHg måles
        {
            calibrate.AddVoltageValue(10);
            button1.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone() == true)
            {
                button6.Enabled = true;
            }

            MessageBox.Show("Målingen er udført");
        }

        private void button2_Click(object sender, EventArgs e) // 30 mmHg måles
        {
            calibrate.AddVoltageValue(30);
            button2.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone() == true)
            {
                button6.Enabled = true;
            }
            MessageBox.Show("Målingen er udført");
        }
       

        private void button3_Click(object sender, EventArgs e) // 50 mmHg måles
        {
            calibrate.AddVoltageValue(50);
            button3.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone() == true)
            {
                button6.Enabled = true;
            }
            MessageBox.Show("Målingen er udført");
        }

        private void button4_Click(object sender, EventArgs e)// 75 mmHg måles
        {
            calibrate.AddVoltageValue(75);
            button4.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone() == true)
            {
                button6.Enabled = true;
            }
            MessageBox.Show("Målingen er udført");
        }

        private void button5_Click(object sender, EventArgs e) // 100 mmHg måles
        {
            calibrate.AddVoltageValue(100);
            button5.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone()==true)
            {
                button6.Enabled = true;
            }
            MessageBox.Show("Målingen er udført");
        }

        private void button6_Click(object sender, EventArgs e) //  kalibrer knappen, er enabled = false i starten.
        {
            IsCalibrateDone = false;

            calibrate.DoCalibrateRegression(); // Kører metoden DoCalibration i logiklaget
            
            MessageBox.Show("Kalibreringen er udført. a = " + calibrationValue._a + "b = " +calibrationValue._b);
            MainGuiRef.UpdateCaliLabel(calibrate.updateCalibrateText()); // opdatere kalibreringstekst i mainGUI

            if (calibrate.GetIsAll5MeasureDone()== true)
            {
                IsCalibrateDone = true;
            }
            else
            {
                IsCalibrateDone = false;
            }
           
            
            
        }
    }
}
