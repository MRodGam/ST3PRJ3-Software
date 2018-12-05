using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public interface IDAQ
    {
        void Start();
        void Stop();
        void GetRawData();

    }
}
