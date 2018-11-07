using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST3PRJ3DAQ;
using Domain;

namespace DataLayer
{
    public class TransducerDAQ : IDAQ
    {
        List<BloodPressure> RawDataList;

        public List<BloodPressure> GetRawData()
        {

            RawDataList = new List<BloodPressure>();

        }
    }
}
