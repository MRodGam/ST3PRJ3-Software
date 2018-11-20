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
    public partial class ChangeLimits : Form
    {
        private int limite = 1;
        public ChangeLimits()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (limite == 1)
            {
            upperLimit.Text = upperLimit.Text + b.Text;
            }

            if (limite == 2)
            { upperLimit.Text = upperLimit.Text + b.Text; }
        }

        private void lowerLimit_Click(object sender, EventArgs e)
        {
            limite = 1;
        }

        private void upperLimit_Click(object sender, EventArgs e)
        {
            limite = 2;

        }

     
    }
}
