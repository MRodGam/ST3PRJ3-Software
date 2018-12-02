using System;
using System.Collections.Concurrent;
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
using System.Runtime.InteropServices.ComTypes;
using DataLayer;


namespace GrafTestprogram
{
    public partial class Form1 : Form, IObserver
    {
        private IDataTreatment dataTreatment;
        private Subject observer;
        private ConvertAlgo converter;
        private delegate void updateGraphDelegate(List<ConvertedData> graphList);

        private UC2M2_UC3M3_Measure Measure;


        private List<ConvertedData> GUIgraphList;

        public int Counter { get; private set; } = 0;
        public int Updates { get; private set; } = 0;
        public bool Running { get; private set; } = false;

        public Form1()
        {
            BlockingCollection<RawData> rawData = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            converter = new ConvertAlgo();
            IDAQ transducerdaq = new TransducerDAQ(daq, rawData);
            DataTreatment dataTreatment = new DataTreatment(rawData, converter);
            Measure = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment);
            InitializeComponent();
            dataTreatment.Attach(this); // Lars
            GUIgraphList = new List<ConvertedData>();
        }

        public void Update()
        {
            GUIgraphList = dataTreatment.GetGraphList();
            UpdateGraph(GUIgraphList);


            Updates++;
        }

        private void UpdateGraph(List<ConvertedData> GUIgraphList)
        {
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new updateGraphDelegate(UpdateGraph), new object[] { GUIgraphList });
                // get other values to update with
            }
            else
            {
                foreach (var sample in GUIgraphList)
                {
                    chart1.Series["Series"].Points.AddXY(sample.Second, sample.Pressure);
                }

                textBox1.Text = Convert.ToString(Updates);
                // Update other values
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Counter++;

            if (Counter % 2 != 0)
            {
                Measure.StartMeasurement();

                Running = true;
                button1.BackColor = Color.Red;
                button1.Text = "STOP MÅLING";
            }
            else
            {
                Measure.StopMeasurement();

                Running = false;
                button1.BackColor = Color.ForestGreen;
                button1.Text = "START MÅLING";
            }
        }
    }
}
