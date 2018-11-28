using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    interface IPulse
    {
        int Pulse(double[] measurements, double samplefrequence);
    }
}
