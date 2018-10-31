using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC2M2_UC3M3_Measure : IMeasure
    {
        public bool Running { get; private set; } = false;
        PresentationLayer

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

        public bool UpdateButtonColours() 
        {
            if (Running ==true)
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
        public void Measure() // Should it be a thread, in order to constant check for whether or not Running is true or false??
        {
            if (Running == true)
            {
                DataLayer.TransducerDAQ.Start();
            }

            if (Running ==false)
            {
                DataLayer.TransducerDAQ.Stop();
            }
        }
    }
}
