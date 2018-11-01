using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Patient
    {

        private int _socSecNumber;
        private string _procedure;

        public Patient(int socSecNumber, string procedure)
        {
            _socSecNumber = socSecNumber;
            _procedure = procedure;
        }


    }
}
