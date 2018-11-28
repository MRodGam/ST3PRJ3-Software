using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Domain;
using LogicLayer;

namespace Presentation
{
    public partial class SaveDataGUI : Form
    {
        private bool check = false;
        private int puls_;
        private int mean_;
        private List<GetCompletMeasurement> getCompletMeasurements_; //omdøb
        private string procedure_;
        private string name_;

        private ISave saveInterface;

        public SaveDataGUI(ISave save)
        {
            saveInterface = save;
        }

        public SaveDataGUI()
        {
            InitializeComponent();
        }
 
        public bool checkCPR(string number) 
        {
            int[] integer = new int[10];
            int counter = 0;

            foreach (char c in number)
            {
                ++counter;
            }

            if (counter != 10)
                return false;

            for (int index = 0; index < 10; index++)
            {
                if (number[index] < '0' || '9' < number[index])
                    return false;
                integer[index] = Convert.ToInt16(number[index]) - 48;
            }

            // Algoritme der kotrollerer om cifrene danner et gyldigt personnummer
            if ((4 * integer[0] + 3 * integer[1] + 2 * integer[2] + 7 * integer[3] + 6 * integer[4] + 5 * integer[5] + 4 * integer[6] + 3 * integer[7] + 2 * integer[8] + integer[9]) % 11 != 0)
                return false;
            else
                return true;
        } // tjekker CPR-nummer
        private void textBox9_TextChanged(object sender, EventArgs e)
        {}

        private void label5_Click(object sender, EventArgs e)
        {} 

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (checkCPR(cprTB1.Text + cprTB2.Text) == false && check == false)
            {
                MessageBox.Show("Tjek venligst, om CPR-nummeret er korrekt indtastet. \nHvis det er korrekt, tryk da på gem igen.");
                check = true;
            }
            else
            {
                string cpr = cprTB1.Text + "-" + cprTB2.Text;
                saveInterface.SaveDataLogic(navnTB.Text,cprTB1.Text, cprTB2.Text, medarbejderIDTB.Text, dateTimePicker1.Text);
                check = false;
                this.Close();
            }
        }
    }
}
