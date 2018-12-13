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
        //således jeg tjekker tryk-værdier igennem for en hel blodtrykskurve, og her finder henholdsvis maks og min og gennemsnit for disse værdier. 
      

        //DataTreatment dataTreatment = new DataTreatment(); // what?

        public int SysBP { get; private set; }
        public int DiaBP { get; private set; }
        public int MeanBP { get; private set; }
        private double value;
        //private int _pulseValue;

        //private int Window = 2000; // antal af samples (tryk-værdier) som der kigges på. 
        //private int CountConvertedDataList;


        // bruges i metoden WindowOfConvertedData
        //private PulseAlgo PulseAlgo;
        //private List<double> _windowOfConvertedData;// 
        private int _nSamplesPrMin = 3600; // antal samples pr. minut
        private int _samplesPrPuls; // antal sample pr. puls
        private List<double> _windowList = new List<double>(); // listen oprettes
        public AutoResetEvent BloodPressureThread { get; set; } // tråd som alarm klassen kører på
        private List<double> _convertedData;



        public BloodPressureAlgo()
        {
            _convertedData = new List<double>();
            //PulseAlgo = new PulseAlgo();
        }

        public BloodPressure WindowOfConvertedData(List<double> convertedData, int pulseValue)
        {
            _convertedData = convertedData;

            _samplesPrPuls = _nSamplesPrMin / pulseValue; // beregner antallet af samples der er mellem hvert pulsslag
            
            if (_convertedData.Count > _samplesPrPuls) // hvis længden af listen for convertedData er længere end _samplePrPuls
            {
                _windowList.Clear(); // Listen for window tømmes

                for (int i = _convertedData.Count - _samplesPrPuls; i < _convertedData.Count; i++) // tager listens længde og går så x antal samples tilbage, og tilføjer samples herfra til windowList. Dvs. der tilføjes 2000 samples (tryk-værdier)
                {
                    _windowList.Add(_convertedData[i]);
                }


            }
            if(_samplesPrPuls <= _convertedData.Count)
            {
                for (int i = _convertedData.Count - _samplesPrPuls; i < _convertedData.Count; i++) // tager listens længde og går så x antal samples tilbage, og tilføjer samples herfra til windowList. Dvs. der tilføjes 2000 samples (tryk-værdier)
                {
                    _windowList.Add(_convertedData[i]);
                }
                
            }
            //else
            //{
            //    for (int i = 0; i < _convertedData.Count; i++)
            //    {
            //        _windowList[i] = _convertedData[i].Pressure;
            //    }
            //}

            return new BloodPressure(FindSystolic(), FindDiastolic(), FindMean()); // er det rigtigt?
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
