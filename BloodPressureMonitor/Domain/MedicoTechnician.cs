using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class MedicoTechnician
    {
        private string _username;
        private int _password;

        public MedicoTechnician(string username, int password)
        {
            _username = username;
            _password = password;
        }
    }
}
