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
        public int MeanBP { get;  }
        private double value;
        private int Window = 5000;
        private int CountConvertedDataList;
        private List<double> _windowList; 


        //public BloodPressureAlgo(List<ConvertedData> _convertedData)
        //{
        //    _convertedData = new List<ConvertedData>();
        //}

        public List<double> WindowOfConvertedData(List<ConvertedData> _convertedData)
        {
            while (true)
            {
                CountConvertedDataList = _convertedData.Count;

                if (CountConvertedDataList>Window)
                {
                    _windowList.Clear();
                    _windowList.AddRange(_convertedData[_convertedData.Count-5000]);
                }

                return _windowList;
            }

            return _windowOfConvertedData;
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
            // min-værdi for de samples der gennemløbes mellem to pulsværdier 

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
            // gennemsnit for de samples der gennemløbes mellem to pulsværdier
        }
    }
}
