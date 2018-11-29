using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class BloodPressureAlgo
    {
        //Converted data listen, som indeholder tryk-værdier, gennemløbes hvert sekund. Der puttes et "vindue" ned over listen, 
        //således jeg tjekker tryk-værdier igennem for 1 sekund, og her finder henholdsvis maks og min og gennemsnit for disse værdier. 
        // dette skal køre så længe der måles, dvs. skal køre i en while(true)

        //DataTreatment dataTreatment = new DataTreatment(); // what?
        
        public int SysBP { get; private set; }
        public int DiaBP { get; private set; }
        public int MeanBP { get; private set; }
        private double value;

        //private int Window = 2000; // antal af samples (tryk-værdier) som der kigges på. 
        //private int CountConvertedDataList;


        // bruges i metoden WindowOfConvertedData
        private PulseAlgo pulseAlgo = new PulseAlgo();
        //private List<double> _windowOfConvertedData;// 
        private int _nSamplesPrMin = 60000; // antal samples pr. minut
        private int _samplesPrPuls; // antal sample pr. puls
        private List<double> _windowList = new List<double>(); // listen oprettes
        public AutoResetEvent BloodPressureThread { get; set; } // tråd som alarm klassen kører på



        //public BloodPressureAlgo(List<ConvertedData> _convertedData)
        //{
        //    _convertedData = new List<ConvertedData>();
        //}

        public List<double> WindowOfConvertedData(List<ConvertedData> convertedData)
        {
            BloodPressureThread.WaitOne(); // kører i tråd, således den hele tiden tjekker om alarmen skal starte. Startes i UCM2_UC3M3_Measure

            while (true) // så længe målingen kører -> hvordan skrives det, er der er properti der skal sættes til true i UCMeasure?
            {
                //CountConvertedDataList = convertedData.Count; // længden af listen sættes lig med attributten "CountConvertedDataList"

                _samplesPrPuls = _nSamplesPrMin / pulseAlgo.PulseValue; // beregner antallet af samples der er mellem hvert pulsslag

                //if (CountConvertedDataList>Window) // hvis længden af listen for convertedData er længere end window (som er 2000)
                //{
                //    _windowList.Clear(); // Listen for window tømmes

                //    for (int i = _convertedData.Count - Window; i < _convertedData.Count; i++) // tager listens længde og går så 2000 samples tilbage, og tilføjer samples herfra til windowList. Dvs. der tilføjes 2000 samples (tryk-værdier)
                //    {
                //        _windowList.Add(_convertedData[i].Pressure);
                //    }


                //}

                if (convertedData.Count > _samplesPrPuls) // hvis længden af listen for convertedData er længere end _samplePrPuls
                {
                    _windowList.Clear(); // Listen for window tømmes

                    for (int i = convertedData.Count - _samplesPrPuls; i < convertedData.Count; i++) // tager listens længde og går så x antal samples tilbage, og tilføjer samples herfra til windowList. Dvs. der tilføjes 2000 samples (tryk-værdier)
                    {
                        _windowList.Add(convertedData[i].Pressure);
                    }


                }

                // for hvert sekund (for hver gang vi opdatere skærmen) skal disse metoder kaldes -> hvor skal det stå, i metoderne?
                // Starter algoritmerne 
                //FindSystolic();
                //FindDiastolic();
                //FindMean();
                BloodPressure BP = new BloodPressure(FindSystolic(), FindDiastolic(), FindMean()); // er det rigtigt?
            }

            
        }

        // find systole 
        public int FindSystolic()
        {
           
            // maks-værdi for de samples der gennemløbes mellem to pulsværdier
           value = _windowList[0];

            for (int i = 0; i < _windowList.Count; i++) // kommenter
            {
                if (value <_windowList[i])
                {
                    value = _windowList[i];
                }
            }

            return SysBP = Convert.ToInt32(value);

        }

        // find diastole 
        public int FindDiastolic()
        {
            // min-værdi for de samples der gennemløbes 

            value = _windowList[0];

            for (int i = 0; i < _windowList.Count; i++) // kommenter
            {
                if (value > _windowList[i])
                {
                    value = _windowList[i];
                }
            }

            return DiaBP = Convert.ToInt32(value); 
        }

        // find middelværdi
        public int FindMean()
        {
            double totalPressureValue = 0; 

            // gennemsnit for de tryk-værdierne i window-listen
            // window-listen gennemløbes
            for (int i = 0; i <_windowList.Count ; i++)
            {
                totalPressureValue = _windowList[i] + totalPressureValue; // samlet værdi for tryk finde
            }

            MeanBP = Convert.ToInt32(totalPressureValue / _windowList.Count); // gennemsnittet for trykværdierne findes
            return MeanBP;

            
        }
    }
}
