using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using alglib;
using MathNet.Numerics; //generating sine waveforms
using MathNet.Numerics.IntegralTransforms;
using System.Numerics; // Complex numbers 
using System.Threading.Thread;

namespace Domain
{
    class PulseAlgo
    {
        private int samplefrekvens_ = 1000;
        

        public PulseAlgo(List<ConvertedData> ConvertedData) //ikke oprettet endnu
        {}

        public void ComplexPulseArray() //laver array med komplekse værdier fra den koverterede pulsliste
        {
            ComplexArray[] complexArray = new ComplexArray[list.Count];
            int i = 0;
            //opretter samples i compleks array
            for (ComplexArray complexArray in list)
            {
                complexArray[i++] = new Complex(ComplexArray);
            }
        }

        public int PulseFourier()
        {
            //Konverterer tid til frekvens 
            Fourier.Forward(complexArray, FourierOptions.NoScaling);  //Skal det være forward eller invers? 


        }

        
        
    }
}
