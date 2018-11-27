using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    class UC9S5_Limits : ILimits
    {
        private double _sysLowerLimit;
        private double _sysUpperLimit;

        //grænseværdierne sættes inde i eventhandler

        public double getLowerLimit()
        {
            return _sysLowerLimit;
        }

        public double getUpperLimit()
        {
            return _sysUpperLimit;
        }
    }
}
