using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class BloodPressureAlgo
    {
        //Converted data listen, som indeholder tryk-værdier, gennemløbes hvert sekund. Der puttes et "vindue" ned over listen, 
        //således jeg tjekker tryk-værdier igennem for 1 sekund, og her finder henholdsvis maks og min og gennemsnit for disse værdier. 
        // dette skal køre så længe der måles, dvs. skal køre i en while(true)

        //DataTreatment dataTreatment = new DataTreatment(); // what?

        private List<double> _windowOfConvertedData;// 

        public int SysBP { get; private set; }
        public int DiaBP { get; private set; }
        public int MeanBP { get; private set; }
        private double value;
        private int Window = 2000; // antal af samples (tryk-værdier) som der kigges på
        private int CountConvertedDataList;
        private List<double> _windowList; 


        //public BloodPressureAlgo(List<ConvertedData> _convertedData)
        //{
        //    _convertedData = new List<ConvertedData>();
        //}

        public List<double> WindowOfConvertedData(List<ConvertedData> _convertedData)
        {
            while (true) // så længe målingen kører -> hvordan skrives det, er der er properti der skal sættes til true i UCMeasure?
            {
                CountConvertedDataList = _convertedData.Count; // længden af listen sættes lig med attributten "CountConvertedDataList"

                if (CountConvertedDataList>Window) // hvis længden af listen for convertedData er længere end window (som er 2000)
                {
                    _windowList.Clear(); // Listen for window tømmes

                    for (int i = _convertedData.Count - Window; i < _convertedData.Count; i++) // tager listens længde og går så 2000 samples tilbage, og tilføjer samples herfra til windowList. Dvs. der tilføjes 2000 samples (tryk-værdier)
                    {
                        _windowList.Add(_convertedData[i].Pressure);
                    }
                        
                    //_windowList.AddRange(_convertedData[_convertedData.Count - Window); // Tilføjer data til listen for window, som længere nede bliver kørt igennem
                    // synes ikke det giver mening at man trækker 5000 fra længden af convertedData, fordi den liste bliver vel bare længere og længere med tiden. 
                    // Det antal af værdier vi gerne vil tilføje til _windowList er vel 5000, og det bliver det ikke hvis koden er skrevet som nu??
                    // er det bedre med array, hvor pladserne rykkes???
                }

                // for hvert sekund (for hver gang vi opdatere skærmen) skal disse metoder kaldes -> hvor skal det stå, i metoderne?
                FindSystolic();
                FindDiastolic();
                FindMean();
            }

            
        }

        // find systole 
        public int FindSystolic()
        {
           
            // maks-værdi for de samples der gennemløbes mellem to pulsværdier
           value = _windowList[0];

            for (int i = 0; i < _windowList.Count; i++) // kommenter
            {
                if (value <_windowOfConvertedData[i])
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
