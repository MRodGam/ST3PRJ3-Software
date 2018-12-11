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
    public partial class LoginToCalibrateGUI : Form
    {
        
        private CalibrateGUI calibrateRef_; // reference til CalibrateGUI

        private string _username = "Admin";
        private int _password = 1234;

        public bool LoginOK { get; private set; } = false; // kan hentes af andres men ikke sættes af andre

        public LoginToCalibrateGUI()
        {
            InitializeComponent();
        }

        private void LoginToCalibrateGUI_Load(object sender, EventArgs e) // hvilken knap er det???
        {
            
        }

        private void username_Click(object sender, EventArgs e)// hvilken knap er det???
        {

        }

        private void loginB_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text == _username && Convert.ToInt32(passwordTB.Text) == _password) // hvis de indtastede login-oplysninger i tekstboksene er de samme som attributterne 
            {
                LoginOK = true;
                
                this.Close(); // login-vinduet lukker ned
            }
            else
                MessageBox.Show("Ikke gyldigt login, prøv igen."); // hvis login ikke er OK kommer dette frem som et vindue 
        }
    }
}
