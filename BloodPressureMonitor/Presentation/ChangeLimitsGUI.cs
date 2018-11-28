using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;

namespace Presentation
{
    public partial class ChangeLimits : Form
    {
        private int limite = 1;

        private UC9S5_Limits _limits = new UC9S5_Limits();

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

        private void okB_Click(object sender, EventArgs e)
        {
            _limits.SysLowerLimit = Convert.ToDouble(upperLimit.Text); // grænseværdierne sættes
            _limits.SysUpperLimit = Convert.ToDouble(lowerLimit.Text);
        }

        private void upperLimit_TextChanged(object sender, EventArgs e)
        {

        }

        private void lowerLimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
