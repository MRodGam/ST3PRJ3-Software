using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class filter : Form
    {
        public filter()
        {
            InitializeComponent();
        }

        private void StartB_Click(object sender, EventArgs e)
        {
            // Is missing a method to do the start/stop eventhandler

            if (UCisMeasurementRunning== true)
            {
                StartB.BackColor = Color.Red;
                StartB.Text = "STOP MÅLING";
            }

            if (isMeasurementRunning == false)
            {
                StartB.BackColor = Color.ForestGreen;
                StartB = "START MÅLING";
            }
        }

        private void StartB_Click_1(object sender, EventArgs e)
        {

        }
    }
}
