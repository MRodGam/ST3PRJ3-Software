using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    interface ISave
    {
        void SaveInDatabase(string CPRno, string IDno, DateTime date, byte[] GetCompletedMeasurement);
        
    }
}
