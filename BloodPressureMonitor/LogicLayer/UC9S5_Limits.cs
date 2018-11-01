using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    class UC9S5_Limits : ILimits
    {
        private double _lowerLimit;
        private double _upperLimit;

        
        public double getLowerLimit()
        {
            return _lowerLimit;
        }

        public double getUpperLimit()
        {
            return _upperLimit;
        }
    }
}
