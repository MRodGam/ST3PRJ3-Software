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
        private DataTreatment dataTreatment;
        private Subject observer;
        private ConvertAlgo converter;
        private delegate void updateGraphDelegate(List<ConvertedData> graphList);
        // private delegate void updateGraphDelegate(List<RawData> graphList);

        private UC2M2_UC3M3_Measure Measure;
        private TextBox textBox1;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private List<ConvertedData> GUIgraphList;
        //private List<RawData> testGraphList;

        public int Counter { get; private set; } = 0;
        public int Updates { get; private set; } = 0;
        public bool Running { get; private set; } = false;

        public Form1()
        {
            BlockingCollection<RawData> rawData = new BlockingCollection<RawData>();
            DAQ daq = new DAQ();
            converter = new ConvertAlgo();
            IDAQ transducerdaq = new TransducerDAQ(daq, rawData);
            dataTreatment = new DataTreatment(rawData, converter);
            Measure = new UC2M2_UC3M3_Measure(transducerdaq, dataTreatment);
            InitializeComponent();
            dataTreatment.Attach(this); // Lars
            GUIgraphList = new List<ConvertedData>();
            //testGraphList = new List<RawData>();
        }

        public void Update()
        {
            GUIgraphList = dataTreatment.GetGraphList();
            // testGraphList = dataTreatment.GetFilterList();

            UpdateGraph(GUIgraphList);
            // UpdateGraph(GUIgraphList);

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
                    chart1.Series["Series1"].Points.AddXY(sample.Second,sample.Pressure);
                }

                textBox1.Text = Convert.ToString(Updates);
                // Update other values
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(178, 546);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 22);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1153, 498);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1165, 580);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
