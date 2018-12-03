using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TegnKurveTestprogram
{
    public partial class Form1 : Form
    {
        private List<double> GUIgraphList;
        public int Updates { get; private set; } = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void Update()
        {
            for (int i = 0; i <100; i++)
            {
                GUIgraphList.Add(i)
            }

            UpdateGraph(GUIgraphList);


            Updates++;
        }

        private void UpdateGraph(List<double> GUIgraphList)
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
    }
}
