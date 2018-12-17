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

namespace PresentationLayer
{
    public partial class CalibrateGUI : Form
    {
        private ICalibrate calibrate; // reference til ICalibrate
        private IMeasure measure; // reference til ICalibrate
        private MainGUI MainGuiRef;

        public bool IsThereNewCalibration { get; private set; }= false;
        //private LoginToCalibrateGUI LoginToCalibrateRef; // er det OK at jeg opretter en new her??

        public CalibrateGUI(ICalibrate calibrate_, IMeasure measure)
        {
            InitializeComponent();
            //LoginToCalibrateRef = loginToCalibrateRef;

            this.Visible = false; // Vinduet skjules til en start, og kommer kun frem hvis login = true (se koden nedenunder)
            calibrate = calibrate_;

            //LoginToCalibrateRef.ShowDialog();

            //if (LoginToCalibrateRef.LoginOK == true)
            //{
            //    this.Visible = true;
            //}
            //else
            //    this.Close(); // denne skal være der for at man ikke bare kan lukke login vinduet og så vil hovedvinduet komme frem, den vil nu lukke
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            calibrate.AddVoltageValue(100);
            button5.Enabled = false;

            // hvis alle 5 målinger er blevet udført bliver det muligt at trykke på "kalibrer"-knappen. Skal stå i hver "mål"-knap, da man kan måle i forskellige rækkefølger
            if (calibrate.GetIsAll5MeasureDone() == true)
            {
                button6.Enabled = true;
            }
            MessageBox.Show("Målingen er udført");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calibrate.DoCalibrateRegression(); // Kører metoden DoCalibration i logiklaget

            MessageBox.Show("Kalibreringen er udført. a = " + calibrate.getCalibrateValue()._a + "b = " + calibrate.getCalibrateValue()._b);
            IsThereNewCalibration = true;
            this.Hide();
            this.Close();
        }
    }
}
