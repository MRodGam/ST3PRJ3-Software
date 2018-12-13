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
        public double SysLowerLimit { get; set; } = 30; // default værdi
        public double SysUpperLimit { get; set; } = 100;

        //grænseværdierne sættes inde i eventhandler


        public double GetLowerLimit()
        {
            return SysLowerLimit;
        }

        public double GetUpperLimit()
        {
            return SysUpperLimit;
        }
    }
}
