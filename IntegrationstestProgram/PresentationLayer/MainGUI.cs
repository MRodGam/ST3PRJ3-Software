using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Domain;
using LogicLayer;

namespace PresentationLayer
{
    public partial class MainGUI : Form, IObserver
    {
        private IAlarm alarm; // Denne oprettes for at vi kan kommunikere med alarm klassen i logik-laget gennem interfacet
        private IMeasure Measure;
        private DataTreatment dataTreatment; // ændet til at kende selve klassen isetdet for inteface
        private IPulse pulse;
        private BloodPressureAlgo bp;

        private LoginToCalibrateGUI Login;
        private ZeroAdjustmentGUI ZeroAdjustmentGui;
        private SaveDataGUI SaveGUI;
        private ChangeLimitsGUI ChangeLimitsGUI;

        private IAlarmType alarmType;
        private IFilter FilterRef;

        private BackgroundWorker muteAlarmWorker;
        private BackgroundWorker ActiveAlarm;

        private delegate void updateGraphDelegate(List<double> graphList);

        private List<double> graphList;

        public int Counter { get; private set; } = 0;
        public bool Running { get; set; } = false;

        public MainGUI(DataTreatment data, IMeasure measure, LoginToCalibrateGUI login, ZeroAdjustmentGUI zeroAdjustmentGui, IAlarm _alarm,IPulse _pulse, BloodPressureAlgo bpAlgo, IFilter filter, SaveDataGUI saveGUI, ChangeLimitsGUI change)
        {
            InitializeComponent();
            ZeroAdjustmentGui = zeroAdjustmentGui;
            alarm = _alarm;
            pulse = _pulse;
            bp = bpAlgo;
            FilterRef = filter;
            SaveGUI = saveGUI;
            ChangeLimitsGUI = change;

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
            ActiveAlarm.RunWorkerAsync();

            dataTreatment = data;
            Measure = measure;
            Login = login;
            dataTreatment.Attach(this); // metoden findes ikke (virker nu da IDataTreatment er udkommenteret, og det isetdet er DataTreatment vi kalder igennem)
            graphList = new List<double>();
        }

        public void Update()
        {
            if (FilterRB.Checked == true)
            {
                graphList = FilterRef.GetFilteredGraphList();
            }

            if (FilterRB.Checked == false)
            {
                graphList = dataTreatment.GetGraphList(); //dataTreatmentRef.FilterData(); // filterData er void, hvis den skal retunere skal den være en liste
            }

            UpdateGraph(graphList);
        }

        private void UpdateGraph(List<double> graphList) // skal ikke være static
        {
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new updateGraphDelegate(UpdateGraph), new object[] { graphList });
            }
            else
            {
                chart1.Series["Series1"].Points.Clear();

                foreach (var sample in graphList)
                {
                    chart1.Series["Series1"].Points.AddY(sample);
                }

                int puls = pulse.FindPulse();
                PulsL.Text = Convert.ToString(puls);

                bp.WindowOfConvertedData(graphList, puls);

                int diastolic = bp.FindDiastolic();
                DiastoliskL.Text = Convert.ToString(diastolic);

                int systolic = bp.FindSystolic();
                SystoliskL.Text = Convert.ToString(systolic);

                int mean = bp.FindMean();
                MiddelL.Text = Convert.ToString(mean);

                if (alarm.GetIsAlarmRunning() == true)
                {
                    ActiveAlarmUpdate();
                }
            }
        }

        private void ActiveAlarmUpdate()
        {
            //alarmType.RunAlarm(); // denne skal afspilles med 5 sekunder mellemrum, skal det stå nede i tråden for ActiveAlarm ??
                                  //Thread.Sleep(5000); // sover 5 sekunder
                                  //alarmType.RunAlarm(); 

            blodtryk_L.ForeColor = Color.Red;
            DiastoliskL.ForeColor = Color.Red;
            SystoliskL.ForeColor = Color.Red;
            middel_L.ForeColor = Color.Red;
            MiddelL.ForeColor = Color.Red;
            AlarmPictureBox.Visible = true;
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

        private void muteAlarmWorker_muteAlarm(object sender, DoWorkEventArgs e) // Denne metode bestemmer hvad der sker, imens backgroundworker kører. // DET HER SKAL LIGGE I BUSINESS
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




        private void button1_Click(object sender, EventArgs e)
        {
            Login.ShowDialog();
        }

        private void StartB_Click_1(object sender, EventArgs e)
        {
            Counter++;

            if (Counter % 2 != 0)
            {
                Measure.StartMeasurement();

                Running = true;
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
                saveB.Enabled = false;
                //calibrateB.Enabled = false;
                clearB.Enabled = false;
            }

            if (Counter % 2 == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Ønsker du, at afslutte målingen?", "Advarelse", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Measure.StopMeasurement();

                    Running = false;
                    StartB.BackColor = Color.CornflowerBlue;
                    StartB.Text = "START MÅLING";
                    saveB.Enabled = true;
                    clearB.Enabled = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void pauseB_Click_1(object sender, EventArgs e)
        {

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void clearB_Click(object sender, EventArgs e) 
        {
            DialogResult dialog = MessageBox.Show("Er du sikker på du vil rydde indstillerne?", "Ryd indstillinger", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Restart();
                Refresh();
            }
            else
            {
                dialog = DialogResult.Cancel;
            }
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            SaveGUI.ShowDialog();
        }

        private void limitsB_Click(object sender, EventArgs e)
        {
            ChangeLimitsGUI.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void calibrateB_Click(object sender, EventArgs e)
        {
            Login.ShowDialog();
        }

        public void UpdateCaliLabel(string NewDate)
        {
            kaliTekst_L.Text = NewDate;
        }

        //private void FilterRB_CheckedChanged_1(object sender, EventArgs e) // den gældende
        //{
        //    if (Running == true && FilterRB.Checked)
        //    {
        //        FilterRef.StartFilter();
        //    }
        //    if (Running == true && FilterRB.Checked == false)
        //    {
        //        FilterRef.StopFilter();
        //    }
        //}
    }

}
