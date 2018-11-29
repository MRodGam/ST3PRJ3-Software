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
    public partial class MainGUI : Form
    {
        
        private IAlarm alarm; // denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private IDataTreatment dataTreatment;
        private IAlarmType muteAlarm;

        private BackgroundWorker muteAlarmWorker;

        private delegate void updateGraphDelegate(IDataTreatment dataInterface);

        private List<ConvertedData> graphList;


        public int Counter { get; private set; } = 0;

        public MainGUI(IDataTreatment data)
        {
            InitializeComponent();
            muteAlarmWorker = new BackgroundWorker();
            muteAlarmWorker.DoWork += new DoWorkEventHandler(muteAlarmWorker_muteAlarm); // Her ændres metoden doWork til det vi vil have den til. 
            muteAlarmWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(muteAlarmWorker_completeMute); // Her ændres completemetoden til det vi vil have den til. 
            muteAlarm = new HighAlarm(); 
            dataTreatment = data;
            dataTreatment.Attach(this);
            graphList = new List<ConvertedData>();
        }

        public void Update(IDataTreatment dataInterface)
        {
            graphList = dataInterface.FilterData();
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

        private void StartB_Click(object sender, EventArgs e)
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
            // Lyd stop
            // Tegn skal op
            // Kvitterknap skal gøres usynlig
            
            pauseB.Visible = false;
            muteAlarmWorker.RunWorkerAsync(); // Denne metode starter backGroundWorker tråden

        }

        private void muteAlarmWorker_muteAlarm(object sender, DoWorkEventArgs e) // Denne metode bestemmer hvad der sker, imens backgroundworker kører. 
        {
            muteAlarm.StopAlarm();
            Thread.Sleep(180000);
            muteAlarm.RunAlarm();
        }

        private void muteAlarmWorker_completeMute(object sender, RunWorkerCompletedEventArgs e) // Denne metode kaldes når BackGroundWorker er færdig
        {
            pauseB.Visible = true;
        }

        private void FilterRB_CheckedChanged(object sender, EventArgs e)
        {
            if (Running == true && FilterRB.Checked)
            {
                dataTreatment.StartFilter(); //Mangler forbindelse til interface
            }
        }

        private void StartB_Click_1(object sender, EventArgs e)
        {

        }

        private void saveB_Click(object sender, EventArgs e)
        {
            //SaveDataGUI.Show();
        }
    }
}
