using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IMeasure
    {
        void StartMeasurement();
        void StopMeasurement();
    }
}
