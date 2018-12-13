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
using Domain;

namespace PresentationLayer
{
    public partial class ZeroAdjustmentGUI : Form
    {
        // Interfaces
        private IZeroAdjustment _zeroAdjustment;
        private UC1M1_ZeroAdjustment _uc1M1Zero;

        // Properties
        public bool IsZeroAdjustmentMeasured { get; set; } = false;
        public double zeroAdjustmentValue { get; private set; }

        public ZeroAdjustmentGUI(IZeroAdjustment zeroAdjustment /*UC1M1_ZeroAdjustment uc1M1Zero*/)
        {
            InitializeComponent();
            // axWindowsMediaPlayer1.settings.setMode("loop", true);
            _zeroAdjustment = zeroAdjustment;
            //_uc1M1Zero = uc1M1Zero;
        }

        private void zeroB_Click(object sender, EventArgs e)
        {
            //zeroAdjustmentValue = _zeroAdjustment.GetZeroAdjustmentValue();
            zeroAdjustmentValue = 1.989;

            if (_zeroAdjustment.IsMeasureRight()==true)
            {
                IsZeroAdjustmentMeasured = true;
                double zeroAdjustmentValue_3dec = (float) zeroAdjustmentValue;
                MessageBox.Show("Nulpunktsjusteringen er sket korrekt. Justeringsværdien er " + zeroAdjustmentValue_3dec);
                this.Close();

            }
            if (_zeroAdjustment.IsMeasureRight() == false)
            {
                MessageBox.Show("Nulpunktsjustering afviger mere end 5% fra den normale værdi");
            }

            zeroAdjustmentValue = 0;

        }
    }
}
