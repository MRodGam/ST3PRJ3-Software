using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Operation
    {
        private string _procedure;
        private DateTime _starTime;
        private DateTime _endTime;


        public Operation(string procedure, DateTime starTime, DateTime endTime, double zeroAdjustmentValue)
        {
            _procedure = procedure;

        }
    }
}
