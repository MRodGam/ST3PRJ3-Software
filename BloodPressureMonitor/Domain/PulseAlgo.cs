using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics; //generating sine waveforms
using MathNet.Numerics.IntegralTransforms;
using System.Numerics; // Complex numbers 
using System.Threading;

namespace Domain
{
    public class PulseAlgo
    {
        public int PulseValue { get; private set; } // har tilføjet denne så jeg kan hente den fra en anden klasse (celia)

        public int Pulse(double[] measurements, double samplefrequence)
        {
            double samplefrequence_ = samplefrequence;
            double[] measurements_ = measurements; // Opretter array til målingerne

            int length = measurements.Length; //Finder antal målinger
            alglib.complex[] complexArray = new alglib.complex[length]; //komplekst array
            List<double> amplitudes = new List<double>(); //listen som skal indeholde amplituderne

            alglib.fftr1d(measurements,out complexArray); //fourier der danner det komplekse array

            foreach (var measurement in complexArray) //Hver måling i det komplekse array gennemløbes
            {
                double amplitude = Math.Sqrt(Math.Pow(measurement.x, 2) + Math.Pow(measurement.y, 2)); //Phytagoras for at finde højden på vektoren
                amplitudes.Add(amplitude);// Beregningen tilføjes til listen som indeholder amplituder
            }

            double maximum = amplitudes[0]; //Den maksimale amplitude vælges som den første i listen
            int index = 0;

            for (int i = 0; i < amplitudes.Count / 2; i++)
            {
                if (amplitudes[i]>maximum) //tjekker om amplituden er højere end den der allerede er valgt
                {
                    maximum = amplitudes[i]; //Hvis den er højere erstattes den med den gemte 
                    index = i; //
                }
            }

            double frequence = (double) samplefrequence_ / measurements_.Length;
            double calcFrequence = frequence * index;

            PulseValue = (int) (calcFrequence * 60);
            return PulseValue; // evt slet da man nu kan hente værdien?
        } //returner pulse
    }
}
    
        

        //private List<ConvertedData> convertedList_;
        //private alglib.complex complexArray;

        //public PulseAlgo(List<ConvertedData> ConvertedData) //ikke oprettet endnu
        //{
        //    convertedList_ = ConvertedData;
        //}

        //public alglib.complex[]
        //    ComplexPulseArray() //laver array med komplekse værdier fra den koverterede dataliste. Returner complexArray
        //{
        //    alglib.complex[] complexArray = new alglib.complex[convertedList_.Count];

        //    alglib.fftr1d(convertedList_<ConvertedData>.ToArray(), out complexArray);

        //    return complexArray;
        //}

        ////det komplekse array skal gennemløbes og længden på vektoren registreres. Den længste vektor er en puls som med grundfrekvensen kan omregnes til pulsslag/min.

        //public double VecorLength()
        //{
        //    complexArray.
        //}
    

    




        
        
    

