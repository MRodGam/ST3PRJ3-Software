using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class MedicoTechnician
    {
        public string Username { get; set; }
        public int Password { get; set; }

        public MedicoTechnician(string username, int password)
        {
            Username = username;
            Password = password;
        }
    }
}
