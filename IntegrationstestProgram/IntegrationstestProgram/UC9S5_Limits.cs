using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC9S5_Limits : ILimits
    {
        // giver det måske mere mening at denne klasse er domæne ??
        public double SysLowerLimit { get; set; } = 70; // default værdi
        public double SysUpperLimit { get; set; } = 180;

        //grænseværdierne sættes inde i eventhandler
        public double SetLowerLimit(double lower)
        {
            SysLowerLimit = lower;
            return SysLowerLimit;
        }

        public double GetLowerLimit()
        {
            return SysLowerLimit;
        }

        public double SetUpperLimit(double upper)
        {
            SysUpperLimit = upper;
            return SysLowerLimit;
        }
        public double GetUpperLimit()
        {
            return SysUpperLimit;
        }
    }
}
