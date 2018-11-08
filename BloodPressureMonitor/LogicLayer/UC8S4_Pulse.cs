using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    class UC8S4_Pulse : IPulse //ikke taget højde for tråde endnu, 
    {
        private List<Måling> rTakkerGrupperListe;
        private List<Måling> rTakkerListe;
        private int AntalRTakker = 0;
        private double frekvens_ = 0;
        private List<Måling> måling_;


        private double grænseVærdi_;

        public UC8S4_Pulse(int frekvens, List<Måling> måling)
        {

            måling_ = måling;
            frekvens_ = frekvens;
        }
        public List<Måling> RTakker(double grænse)
        {
            grænseVærdi_ = grænse;
            rTakkerGrupperListe = new List<Måling>();
            rTakkerListe = new List<Måling>();

            foreach (Måling m in måling_) //rTakkerListen fyldes med tomme målinger
            {
                rTakkerListe.Add(new Måling(0, 0));

                if (m.y >= grænseVærdi_) //Alle målinger over grænseværdien tilføjes til rTakkerGrupperListen
                {

                    rTakkerGrupperListe.Add(m);

                }
            }

            int p = 0;
            bool ny = false;

            for (int i = 0; i < rTakkerGrupperListe.Count - 1; i++) //Alle målinger i rTakkerGrupperListen tjekkes
            {
                if (Math.Round(rTakkerGrupperListe[i].x + (1 / frekvens_), 2) == Math.Round(rTakkerGrupperListe[i + 1].x, 2)) //Her tjekkes det, om to målinger i rTakkerGrupperListen er målt lige efter hinanden
                {

                    if (rTakkerGrupperListe[i].y > rTakkerGrupperListe[i + 1].y) //Nu tjekkes der, om den første måling er større end den næste måling
                    {
                        if (rTakkerGrupperListe[i].y > rTakkerListe[p].y) //Og her tjekkes, om målingen er større end den måling, som indtil videre er angivet som den pågældende r-tak. P er altså hvilket nummer r-tak, vi er kommet til. 
                        {
                            rTakkerListe[p] = rTakkerGrupperListe[i]; //R-takken registreres
                            ny = true; //True fortæller, at der nu er registreret en værdi for den pågælde r-tak
                        }
                    }
                    else if (rTakkerGrupperListe[i + 1].y > rTakkerListe[p].y) //Her tjekkes det, om den anden måling er større end den første måling
                    {
                        rTakkerListe[p] = rTakkerGrupperListe[i + 1]; //Se ovenstående
                        ny = true;
                    }
                }
                else if (ny == true) //Hvis de to målinger ikke er i rækkefølge, tjekkes det, om der er registreret en værdi for den pågælde r-tak. Altså nummer p r-tak. 
                {
                    p++; //Der lægges en til p, da det nu er den næste r-taks værdi, som skal findes
                    ny = false; //Der registreres derfor, at der ikke er nogen værdier for den nye r-tak
                }
            }
            return rTakkerListe; //Listen med alle r-takker returneres
        }



        public double BeregnPuls(double grænse)
        {
            double total = 0;

            for (int i = 0; i < RTakker(grænse).Count - 1; i++) //Hver r-tak gennemgåes
            {
                if (RTakker(grænse)[i + 1].y != 0) //Da r-takkerListen blev oprettet med en masee tomme målinger, betyder det, at der ligger rigtig mange målinger i listen, som har værdien nul. Disse skal ikke gennemgåes.
                {
                    AntalRTakker++; //Der tælles, hvormange r-takker der er målt
                    total += RTakker(grænse)[i + 1].x - RTakker(grænse)[i].x; //Tid imellem to r-takker lægges til totalen
                }
                else
                    i = RTakker(grænse).Count - 1; //Hvis næste plads i listen er tom, betyder det, at der ikke er flere r-takker, og derfor ikke flere målinger, som skal registreres
            }

            return Math.Round(60 / (total / AntalRTakker), 0); //Pulsen beregnes ud fra antal rtakker og afstanden i mellem dem ift. pr. minut. Tallet rundes op/ned til nærmeste hele tal. 
        }
    }
}
