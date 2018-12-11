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

        private ICalibrate Icalibrate;
        private IAlarm alarm; // Denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private DataTreatment dataTreatment; // ændet til at kende selve klassen isetdet for inteface
        private IAlarmType alarmType;
        private ZeroAdjustmentGUI ZeroAdjustmentGui;
        private UC7S3_Filter FilterRef;
        private BloodPressureAlgo BloodPressureAlgoRef;
        private PulseAlgo PulseAlgoRef;
        private IPulse IPulseRef;
        private CalibrateGUI CalibrateGUIRef;

        private BackgroundWorker muteAlarmWorker;
        private BackgroundWorker ActiveAlarm;

        private delegate void updateGraphDelegate(List<ConvertedData> graphList);

        private List<ConvertedData> graphList;


        public int Counter { get; private set; } = 0;
        public bool Running { get; set; } = false;

        public MainGUI(DataTreatment data, ZeroAdjustmentGUI zeroAdjustmentGui, UC7S3_Filter filterRef, BloodPressureAlgo bloodPressureAlgoRef, PulseAlgo pulseAlgoRef, IPulse iPulseRef, CalibrateGUI calibrateGuiRef, ICalibrate Icali)
        {
            InitializeComponent();
            ZeroAdjustmentGui = zeroAdjustmentGui;
            BloodPressureAlgoRef = bloodPressureAlgoRef;
            PulseAlgoRef = pulseAlgoRef;
            iPulseRef = IPulseRef;
            CalibrateGUIRef = calibrateGuiRef;
            Icalibrate = Icali;

            this.Visible = false; // Vinduet skjules til en start, og kommer kun frem hvis nulpunktsjusteringen foretages


            ZeroAdjustmentGui.ShowDialog();

            if (ZeroAdjustmentGui.IsZeroAdjustmentMeasured == true)
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
                graphList = FilterRef.GetFiltredGraphList();
            }

            if (FilterRB.Checked == false)
            {
                graphList = dataTreatmentRef.GetGraphList(); //dataTreatmentRef.FilterData(); // filterData er void, hvis den skal retunere skal den være en liste
            }

            UpdateGraph(graphList);

            BloodPressureAlgoRef.WindowOfConvertedData(graphList, PulseAlgoRef.PulseValue); // kalder metoden for at finde blodtryksværdier
            IPulseRef.FindPulse();

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
                DialogResult dialogResult = MessageBox.Show("Ønsker du, at afslutte målingen?","Hallo", MessageBoxButtons.YesNo);
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


        private void clearB_Click(object sender, EventArgs e)
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

        private void StartB_Click_1(object sender, EventArgs e)
        {

        }

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
            CalibrateGUIRef.ShowDialog();

            if (CalibrateGUIRef.IsCalibrateDone == true)
            {
                kaliTekst_L.Text = Icalibrate.updateCalibrateText();
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
