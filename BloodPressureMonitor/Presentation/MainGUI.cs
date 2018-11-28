using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using Domain;

namespace Presentation
{
    public partial class filter : Form // what?
    {
        
        private IAlarm alarm; // denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private IDataTreatment dataTreatment;

        private BackgroundWorker muteAlarmWorker;

        private delegate void updateGraphDelegate(IDataTreatment dataInterface);


        public int Counter { get; private set; } = 0;

        public filter()
        {
            InitializeComponent();
            muteAlarmWorker = new BackgroundWorker();
            
        }

        public void (IDataTreatment dataInterface)
        {
            dataTreatment = dataInterface;
        }

        private static void UpdateGraph(List<ConvertedData> graphList)
        {
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new updateGraphDelegate(UpdateGraph), new object[]{graphList});
            }
            else
            {
                foreach (var sample in graphList)
                {
                    chart1.Series["Series"].Points.AddXY(sample.Second, sample.Pressure);
                }
            }
        }

        private void StartB_Click(object sender, EventArgs e) // Der skal laves en delegate
        {
            Counter++;

            if (Counter % 2 == 0)
            {
                Measure.StartMeasurement();

                Running = true;
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
            }
            if (Counter % 2 != 0)
            {
                Measure.StopMeasurement();

                Running = false;
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

        private void FilterRB_CheckedChanged(object sender, EventArgs e)
        {
            if (Running == true && FilterRB.Checked)
            {
                dataTreatment.StartFilter(); //Mangler forbindelse til interface
            }
        }
    }
}
