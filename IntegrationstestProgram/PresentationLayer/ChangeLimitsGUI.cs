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


namespace PresentationLayer
{
    public partial class ChangeLimitsGUI : Form
    {
        private int limit = 1;

        private ILimits LimitInterface;

        public ChangeLimitsGUI(ILimits limits)
        {
            InitializeComponent();
            LimitInterface = limits;
        }

        private void okB_Click(object sender, EventArgs e)
        {
            //int maxLimit = 200; // ændres??
            //int minLimit = 25; // ændres?

            //if (minLimit <= Convert.ToDouble(lowerLimit.Text) && Convert.ToDouble(upperLimit.Text) <= maxLimit)
            //{
            //    LimitInterface.SetUpperLimit(Convert.ToDouble(upperLimit.Text)); // grænseværdierne sættes
            //    LimitInterface.SetUpperLimit(Convert.ToDouble(lowerLimit.Text));
            //    MessageBox.Show("De nye grænseværdier er nu gældende. Systole: " + upperLimit.Text + "Diastole: " + lowerLimit.Text);
            //    // vandrette linjer på grafen rettes til

            //}
            //else
            //    MessageBox.Show("Ikke gyldige værdier er valgt. Vælg andre grænseværdier.");

            LimitInterface.SetUpperLimit(Convert.ToDouble(upperLimit.Text));
            LimitInterface.SetLowerLimit(Convert.ToDouble(lowerLimit.Text));
            MessageBox.Show("De nye grænseværdier er nu gældende. Systole: " + upperLimit.Text + "Diastole: " + lowerLimit.Text);
            this.Close();
        }

        private void lowerLimit_TextChanged(object sender, EventArgs e)
        {
            limit = 1;
        }

        private void upperLimit_TextChanged(object sender, EventArgs e)
        {
            limit = 2;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (limit == 1)
            {
                upperLimit.Text = upperLimit.Text + b.Text;
            }

            if (limit == 2)
            { upperLimit.Text = upperLimit.Text + b.Text; }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
