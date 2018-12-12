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
        // Interfaces
        private IAlarm alarm; // Denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private DataTreatment dataTreatment; // ændet til at kende selve klassen isetdet for inteface
        private IAlarmType alarmType;
        private IFilter FilterRef;
        private IPulse PulseRef;

        // Algorithms
        private BloodPressureAlgo BloodPressureAlgoRef;
        private PulseAlgo PulseAlgoRef;

        // User interfaces
        private LoginToCalibrateGUI loginGUIRef;
        private ZeroAdjustmentGUI zeroAdjustmentGUIRef;

        //Background workers
        private BackgroundWorker muteAlarmWorker;
        private BackgroundWorker ActiveAlarm;

        // Delegates
        private delegate void updateGraphDelegate(List<ConvertedData> graphList);

        // Lists
        private List<ConvertedData> graphList;

        // Properties
        public int Counter { get; private set; } = 0;
        public bool Running { get; set; } = false;

        public MainGUI(DataTreatment data, ZeroAdjustmentGUI zeroAdjustmentGui, IFilter filterRef, BloodPressureAlgo bloodPressureAlgoRef, PulseAlgo pulseAlgoRef, IPulse iPulseRef, LoginToCalibrateGUI login)
        {
            InitializeComponent();
            zeroAdjustmentGUIRef = zeroAdjustmentGui;
            BloodPressureAlgoRef = bloodPressureAlgoRef;
            PulseAlgoRef = pulseAlgoRef;
            PulseRef = iPulseRef;
            loginGUIRef = login;

            this.Visible = false; // Vinduet skjules til en start, og kommer kun frem hvis nulpunktsjusteringen foretages


            zeroAdjustmentGUIRef.ShowDialog();

            if (zeroAdjustmentGUIRef.IsZeroAdjustmentMeasured == true)
            {
                this.Visible = true;
                StartB.Enabled = true; // knappen er til at starte med ikke enable, bliver først hvis nulpunktsjusteringen udføres
            }
            else
                this.Close(); // denne skal være der for at man ikke bare kan lukke login vinduet og så vil hovedvinduet komme frem, den vil nu lukke
        
            
            muteAlarmWorker = new BackgroundWorker();
            muteAlarmWorker.DoWork += new DoWorkEventHandler(muteAlarmWorker_muteAlarm); // Her ændres metoden doWork til det vi vil have den til. 
            muteAlarmWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(muteAlarmWorker_completeMute); // Her ændres completemetoden til det vi vil have den til. 
            alarmType = new HighAlarm();

            ActiveAlarm = new BackgroundWorker();
            ActiveAlarm.DoWork += new DoWorkEventHandler(ActiveAlarmUpdate_doWork);
            ActiveAlarm.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DeactiveAlarmUpdate);

            dataTreatment = data;
            dataTreatment.Attach(this); // metoden findes ikke (virker nu da IDataTreatment er udkommenteret, og det isetdet er DataTreatment vi kalder igennem)
            graphList = new List<ConvertedData>();

            //filterRef = new UC7S3_Filter();
            FilterRef = filterRef;

        }

        public void Update(DataTreatment dataTreatmentRef)
        {
            if (FilterRB.Checked == true)
            {
                // graphList = FilterRef.GetFiltredGraphList();
                        //Add this when we are testing the filter
            }

            if (FilterRB.Checked == false)
            {
                graphList = dataTreatmentRef.GetGraphList(); 
            }

            UpdateGraph(graphList);

            // BloodPressureAlgoRef.WindowOfConvertedData(graphList, PulseAlgoRef.PulseValue); // kalder metoden for at finde blodtryksværdier
            // IPulseRef.FindPulse();
                        // Add these two when we are ready to test the pulse algorithm

        }

        private void UpdateGraph(List<ConvertedData> graphList) // skal ikke være static
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

            if (alarm.GetIsAlarmRunning() == true)
            {
                ActiveAlarmUpdate();
            }

            //if (alarm.GetIsAlarmRunning() == false)
            //{
            //    alarm.DeactiveAlarmUpdate((object)this, new RunWorkerCompletedEventArgs() ); // hvordan ????
            //}
        }

        private void StartB_Click_1(object sender, EventArgs e)
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
                DialogResult dialogResult = MessageBox.Show("Ønsker du, at afslutte målingen?", "Advarelse", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Measure.StopMeasurement();

                    Running = false;
                    StartB.BackColor = Color.ForestGreen;
                    StartB.Text = "START MÅLING";
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void ActiveAlarmUpdate()
        {

            alarmType.RunAlarm(); // denne skal afspilles med 5 sekunder mellemrum, skal det stå nede i tråden for ActiveAlarm ??
            //Thread.Sleep(5000); // sover 5 sekunder
            //alarmType.RunAlarm(); 

            blodtryk_L.ForeColor = Color.Red;
            middel_L.ForeColor = Color.Red;
            AlarmPictureBox.Visible = true;
            ActiveAlarm.RunWorkerAsync();
        }

        private void ActiveAlarmUpdate_doWork(object sender, DoWorkEventArgs e)
        {
            while (alarm.GetIsAlarmRunning() == true)
            {
                // tallene for blodtryk skal blinke med en bestemt frekvens 
                // billede for aktiv alarm skal være synlig
                
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
                Thread.Sleep(500);
            }
        }

        private void DeactiveAlarmUpdate(object sender, RunWorkerCompletedEventArgs e)
        {

            blodtryk_L.ForeColor = Color.DarkGreen;
            middel_L.ForeColor = Color.DarkGreen;
            // tallene for blodtryk skal STOPPE med at blinke
            // alle billeder/tegn for alarm skal være usynlige igen 
            // alle billeder/tegn for alarm skal være usynlige igen
            AlarmPictureBox.Visible = false;
            AlarmPausedPictureBox.Visible = false;


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
            alarmType.StopAlarm();
            Thread.Sleep(180000);
            alarmType.RunAlarm();
        }

        private void muteAlarmWorker_completeMute(object sender, RunWorkerCompletedEventArgs e) // Denne metode kaldes når BackGroundWorker er færdig
        {
            pauseB.Visible = true;
            AlarmPausedPictureBox.Visible = false;
        }

        //private void FilterRB_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (Running == true && FilterRB.Checked)
        //    {
        //        dataTreatment.StartFilter(); //Mangler forbindelse til interface
        //    }
        //}


        private void FilterRB_CheckedChanged_1(object sender, EventArgs e) // den gældende
        {
            if (Running == true && FilterRB.Checked)
            {
                FilterRef.StartFilter(); 
            }
            if (Running == true && FilterRB.Checked==false)
            {
                FilterRef.StopFilter();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginGUIRef.ShowDialog();
        }

        private void clearB_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Er du sikker på du vil rydde instillerne?", "Ryd instillinger", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Restart();
                Refresh(); // hardcoded, kan laves om hvis der er tid 
            }
            else
            {
                dialog = DialogResult.Cancel;
            }
        }







        //void clear()
        //{
        //  FilterRB. //mangler 
        //lowerlimit.text(""); //mangler forbindelse 
        //upperLimit.text(""); //mangler forbindelse 
        //puls_L.ResetText();
        //blodtryk_L.ResetText();
        //middel_L.ResetText();
        //chart1.//mangler 
        // }







    }
    
}
