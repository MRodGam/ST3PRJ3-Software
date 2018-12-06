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

namespace Presentation
{
    public partial class ZeroAdjustmentGUI : Form
    {
        private IZeroAdjustment _zeroAdjustment;
        private UC1M1_ZeroAdjustment _uc1M1Zero;

        public bool IsZeroAdjustmentMeasured { get; set; } = false;
        
        public ZeroAdjustmentGUI(IZeroAdjustment zeroAdjustment, UC1M1_ZeroAdjustment uc1M1Zero)
        {
            InitializeComponent();
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            _zeroAdjustment = zeroAdjustment;
            _uc1M1Zero = uc1M1Zero;
        }

        private void zeroB_Click(object sender, EventArgs e)
        {
            _zeroAdjustment.GetZeroAdjustmentValue();

            if (_uc1M1Zero.IsZeroAdjustDone == true)
            {
                IsZeroAdjustmentMeasured = true;
                this.Close();
            }
            else if (_uc1M1Zero.IsZeroAdjustDone == false)
            {
                MessageBox.Show("Nulpunktsjustering ikke foretaget korrekt, se videoen igen");
            }
           


        }

        private void ZeroAdjustmentGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
