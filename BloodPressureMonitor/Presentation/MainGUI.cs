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
    public partial class MainGUI : Form, IObserver
    {
        
        private IAlarm alarm; // denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private IDataTreatment dataTreatment;
        private IAlarmType muteAlarm;
        private Observer observer;

        private BackgroundWorker muteAlarmWorker;
        private BackgroundWorker ActiveAlarm;

        private delegate void updateGraphDelegate(IDataTreatment dataInterface);

        private List<ConvertedData> graphList;

        public bool Running { get; private set; }


        public int Counter { get; private set; } = 0;

        public MainGUI(IDataTreatment data)
        {
            InitializeComponent();

            dataTreatment = data;
            dataTreatment.Attach(this);

            muteAlarmWorker = new BackgroundWorker();
            muteAlarmWorker.DoWork += new DoWorkEventHandler(muteAlarmWorker_muteAlarm); // Her ændres metoden doWork til det vi vil have den til. 
            muteAlarmWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(muteAlarmWorker_completeMute); // Her ændres completemetoden til det vi vil have den til. 
            muteAlarm = new HighAlarm();

            ActiveAlarm = new BackgroundWorker();
            ActiveAlarm.DoWork += new DoWorkEventHandler(ActiveAlarmUpdate_doWork);
            ActiveAlarm.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(DeactiveAlarmUodate);

            graphList = new List<ConvertedData>();
        }

        public void Update(IDataTreatment dataInterface)
        {
            graphList = dataInterface.FilterData();
            UpdateGraph(graphList);
            
        }

        private static void UpdateGraph(List<ConvertedData> graphList) // Giver fejl, forid den er static - snak med Lars
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

                if (alarm.GetIsAlarmRunning()==true)
                {
                    ActiveAlarmUpdate(); // skal være static eller?
                   
                                        
                }
                // if sætning ift hvis Alarmen kvitteres 

                if (alarm.GetIsAlarmRunning()==false)
                {
                    DeactiveAlarmUpdate();

                }
            }
        }

        private void ActiveAlarmUpdate()// skal være static eller?
        {
           blodtryk_L.ForeColor = Color.Red;
           middel_L.ForeColor = Color.Red;

            AlarmPictureBox.Visible = true;

            ActiveAlarm.RunWorkerAsync();

            //while (alarm.GetIsAlarmRunning()==true)
            //{
            //    // tallene for blodtryk skal blinke med en bestemt frekvens 
            //    // billede for aktiv alarm skal være synlig
            //}


        }

        private void ActiveAlarmUpdate_doWork(object sender, DoWorkEventArgs e)
        {
            while (alarm.GetIsAlarmRunning() == true)
            {
                Thread.Sleep(500);      // Tallene blinker med en frekvens på 2 Hz, da den skal ligge mellem 1.4-2.8, og med en duty cycle på 50%
                if (blodtryk_L.ForeColor == Color.Red)
                {
                    blodtryk_L.ForeColor = Color.Black;
                    middel_L.ForeColor = Color.Black;
                }
                else
                {
                    blodtryk_L.ForeColor = Color.Red;
                    middel_L.ForeColor = Color.Red;
                }
            }

            
        }

        private void DeactiveAlarmUodate(object sender, RunWorkerCompletedEventArgs e)
        {
            
            blodtryk_L.ForeColor = Color.DarkGreen;
            middel_L.ForeColor = Color.DarkGreen;
            // tallene for blodtryk skal STOPPE med at blinke

            // alle billeder/tegn for alarm skal være usynlige igen

            AlarmPictureBox.Visible = false;
            AlarmPausedPictureBox.Visible = false;

        }

        private void MuteAlarmUpdate()
        {
            // design for GUI når alarmen kvitteres 

            // billede for mute alarm skal være synlig 
        }

        private void StartB_Click(object sender, EventArgs e)
        {
            
            Counter++;

            if (Counter % 2 != 0)
            {
                Measure.StartMeasurement();
                
                Running = true;
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
            }
            else
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
            AlarmPictureBox.Visible = false;
            AlarmPausedPictureBox.Visible = true;
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

        private void clearB_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
