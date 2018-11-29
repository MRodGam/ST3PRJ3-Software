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
        public double SysLowerLimit { get; set; }
        public double SysUpperLimit { get; set; }

        //grænseværdierne sættes inde i eventhandler
       

        //public double GetLowerLimit(double sysLowerLimit)
        //{
        //    _sysLowerLimit = sysLowerLimit;
        //    return _sysLowerLimit;
        //}

        //public double GetUpperLimit(double sysUpperLimit)
        //{
        //    _sysUpperLimit = sysUpperLimit;
        //    return _sysUpperLimit;
        //}
    }
}
