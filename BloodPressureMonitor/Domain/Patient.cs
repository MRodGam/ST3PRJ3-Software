using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Patient
    {

        public int SocSecNumber { get; set; }
        public string Procedure { get; set; }

        public Patient(int socSecNumber, string procedure)
        {
            SocSecNumber = socSecNumber;
            Procedure = procedure;
        }


    }
}
