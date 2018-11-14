﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    class UC2M2_UC3M3_Measure : IMeasure
    {
        public bool isGUIRunning { get; private set; } = false; // Accessed from the user interface
        public bool isMeasurementRunning { get; private set; }
        private static Thread checkifRunningThread;
        public static bool ShallStop { get; private set; }

        public UC2M2_UC3M3_Measure()
        {

        }

        public bool MeasurementStarted()
        {
            isGUIRunning = true;
        }

        public bool IsMeasurementRunning() //Check with Lars, might be very very wrong. Im just stupid
        {
            if (isGUIRunning == true)
            {
                isMeasurementRunning = true;
            }

            if (isGUIRunning == false)
            {
                isMeasurementRunning = false;
            }

            return isMeasurementRunning;
        }

        //public void StartMeasurement() // Sets Running to true, starts method Measure(), updates user interface
        //{
        //    Running = true;
        //    Measure();
        //}

        //public void StopMeasurement() // Sets Running to false, updates user interface
        //{
        //    Running = false;
        //    Measure();
        //}


        public void Measure() 
        {
            if (isMeasurementRunning == true)
            {
                TransducerDAQ.Start();
            }

            if (isMeasurementRunning == false)
            {
                TransducerDAQ.Stop();
                ShallStop = true;
            }

        }

        public void StartMeasurement()
        {
            TransducerDAQ.Start();
        }

        public void StopMeasurement()
        {
            TransducerDAQ.Stop();
        }
    }
}
