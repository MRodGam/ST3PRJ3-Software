﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public class TransducerDAQ : IDAQ // Producer
    {
        public List<double> RawDataList { get; private set; }
        private static Thread measurementThread;
        public static bool ShallStop { get; private set; }
        public DAQ localDAQ;
        private BlockingCollection<double> _collection;
        private BlockingCollection<double> _calibrationCollection;


        public TransducerDAQ(DAQ actualDAQ, BlockingCollection<double> collection, BlockingCollection<double> calibrateCollection) // Takes a DAQ parameter, so that we're sure it will be conected to thesae DAQ as the remaining classes when they are initiated
        {
            localDAQ = actualDAQ;

            _collection = collection;
            _calibrationCollection = calibrateCollection;

            RawDataList = new List<double>();
        }


        public void Start()
        {
            measurementThread = new Thread(GetRawData);
            ShallStop = false; // Sets  ShallStop back to false. 
            measurementThread.Start(); //
        }


        public void Stop()
        {
            ShallStop = true; // Stops thread. 
        }

        public void StartCalibration()
        {
            localDAQ.CollectData();

            foreach (var obj in localDAQ.GetCollectedRawData())// Transfers content measured from the DAQ to the collection
            {
                _calibrationCollection.Add(obj);
            }
        }

        public void GetRawData() // This method is used exclusively by the measuring thread 
        {
            while (!ShallStop)
            {
                localDAQ.CollectData(); // Starts the data collection

                foreach (var obj in localDAQ.GetCollectedRawData())// Transfers content measured from the DAQ to the collection
                {
                    _collection.Add(obj);
                }
            }
        }
    }
}
