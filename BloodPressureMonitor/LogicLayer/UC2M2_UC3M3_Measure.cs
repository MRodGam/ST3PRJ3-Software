using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC2M2_UC3M3_Measure : IMeasure
    {
        public bool Running { get; private set; } = false;
        

        public void StartMeasurement() // Sets Running to true, starts method Measure(), updates user interface
        {
            Running = true;
            UpdateButtonColours();
            Measure();
        }

        public void StopMeasurement() // Sets Running to false, updates user interface
        {
            Running = false;
            UpdateButtonColours(); 
        }

        public void UpdateButtonColours() 
        {
            if (Running ==true) //Det her skal rettes
            {
                MainGUI.StartB.Background = red;
                MainGUI.StartB.Text = "STOP MÅLING";
            }

            if (Running == false)
            {
                MainGUI.StartB.Background = forestGreen;
                MainGUI.StartB.Text = "START MÅLING";
            }

        }

        public void Measure() 
        {

            if (Running == true)
                DataLayer.TransducerDAQ.Start();

            if (Running ==false)
                DataLayer.TransducerDAQ.Stop();
        }
    }
}
