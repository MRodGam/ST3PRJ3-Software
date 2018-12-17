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

        public ZeroAdjustmentGUI(IZeroAdjustment zeroAdjustment)
        {
            InitializeComponent();
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            _zeroAdjustment = zeroAdjustment;
        }

        private void zeroB_Click(object sender, EventArgs e)
        {
            zeroAdjustmentValue = 0;
            zeroAdjustmentValue = _zeroAdjustment.GetZeroAdjustmentValue();
            bool WasItCorrect = _zeroAdjustment.IsMeasureRight();

            if (WasItCorrect == true)
            {
                IsZeroAdjustmentMeasured = true;
                double zeroAdjustmentValue_3dec = Math.Round(zeroAdjustmentValue,3);
                MessageBox.Show("Nulpunktsjusteringen er sket korrekt. Justeringsværdien er " + zeroAdjustmentValue_3dec);
                this.Close();

            }
            if (WasItCorrect == false)
            {
                MessageBox.Show("Nulpunktsjustering afviger mere end 5% fra den normale værdi.");
            }
        }
    }
}
