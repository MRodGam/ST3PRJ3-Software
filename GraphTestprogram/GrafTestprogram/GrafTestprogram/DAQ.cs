using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NationalInstruments.DAQmx;
using ST2Prj2LibNI_DAQ;


namespace DataLayer
{
    public class DAQ
    {
        List<RawData> TotalRawDataList;
        List<RawData> ShortSampleDataList;
        double[] Raw1000DataArray;
        public bool isListfull { get; private set; } = false;
        // public bool isDatacollectionRunning { get; set; }

        public DAQ()
        {
            // isDatacollectionRunning = false;
        }
        public void CollectData()
        {
            isListfull = false;
            Raw1000DataArray = new double[1000]; // 1000 means the screen would be updates every second
            ShortSampleDataList = new List<RawData>();

            NIDAQVoltage datacollector = new NIDAQVoltage(); //Creates a DAQ-object
                // Should it do this here? Didn't I talk to Lars about creating the transducer through the constructor?

            datacollector.samplesPerChannel = 1000; // 1000 means the screen would be updated every second

            datacollector.deviceName = "Dev1/ai0"; // The name is from last semester; should be ok still.

            datacollector.getVoltageSeqBlocking(); // Start datacollection. OBS, this method block some data collection. We might have to consider changing this method to one that doesn't block the data collection.
                // It blocks because it fills the array, then adds it to the list, and then starts the measurement again.
                // The samples that are measured during the time it takes for it to save it to the list are lost
                // Run a sinusoidal curve through the system and see how much the damage is before deciding to change it; it might be okay.

            Raw1000DataArray = datacollector.currentVoltageSeqArray; // Inserts the collected datainto the array

            for (int i = 0; i < Raw1000DataArray.Length; i++)
            {
                double second = 0.001 * (i + 1); // It is the timespacing between the given samples.
                    // plus 1 because arrays start at 0 and we start counting samples at the first sample.

                ShortSampleDataList.Add(new RawData(second, Math.Round((Raw1000DataArray[i]), 3)));
            }

            isListfull = true;
        }

        public List<RawData> GetCollectedRawData()
        {
            return ShortSampleDataList;
        }
        
    }
}
