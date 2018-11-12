using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NationalInstruments.DAQmx;


namespace DataLayer
{
    public class DAQ
    {
        List<RawData> TotalRawDataList;
        List<RawData> ShortSampleDataList;
        double[] Raw1000DataArray;
        public bool isDatacollectionRunning { get; set; }

        private BlockingCollection<RawData> _collection; // Taken from Troels lesson on producer consumer. I guess this is the producer?

        public DAQ(BlockingCollection<RawData> collection)
        {
            isDatacollectionRunning = false;
            _collection = collection;

        }
        public void CollectData()
        {
            while (isDatacollectionRunning == true)
            {
                Raw1000DataArray = new double[1000]; // 1000 should be exchanged for the amount of samples measured during a single update
                ShortSampleDataList = new List<RawData>();

                NIDAQVoltage datacollector = new NIDAQVoltage(); //Creates a DAQ-object
                // Should it do this here? Didn't I talk to Lars about creating the transducer through the constructor?

                datacollector.samplesPerChannel = 1000; // 1000 should be exchanged for the amount of samples measured during a single update

                datacollector.deviceName = "Dev1/ai0"; // The name is from last semester; should be ok still.

                datacollector.getVoltageSeqBlocking(); // Start datacollection. OBS, this method block some data collection. We might have to consider changing this method to one that doesn't block the data collection.
                // It blocks because it fills the array, then adds it to the list, and then starts the measurement again.
                // The samples that are measured during the time it takes for it to save it to the list are lost
                // Run a sinusoidal curve through the system and see how much the damage is before deciding to change it; it might be okay.

                Raw1000DataArray = datacollector.currentVoltageSeqArray; // Inserts the collected datainto the array

                for (int i = 0; i < Raw1000DataArray.Length; i++)
                {
                    double sekunder = 0.004 * (i + 1); //The 0.004 should be changed depending on the sample frequency. It is the timespacing between the given samples.
                    // plus 1 because arrays start at 0 and we start counting samples at the first sample.

                    // ShortSampleDataList.Add(new RawData(sekunder, Math.Round((Raw1000DataArray[i]), 3))); // The voltage value is being rounded down into a number with three decimals.
                    // This is the way we've done it before.

                    // This is my attempt at making a producer thread 
                    _collection.Add(new RawData(sekunder, Math.Round((Raw1000DataArray[i]), 3)));
                }
            }

        }

        public List<RawData> GetRawData()
        {
            return ShortSampleDataList;
        }
        
    }
}
