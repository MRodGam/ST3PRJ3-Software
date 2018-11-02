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
        private DateTime _startTime;
        private DateTime _endTime;

        private double _zeroAdjustmentValue;
        private double _calibrationValue;


        public Operation(string procedure, DateTime startTime, DateTime endTime, double zeroAdjustmentValue, double calibrationValue)
        {
            _procedure = procedure;
            _startTime = startTime;
            _endTime = endTime;

            _zeroAdjustmentValue = zeroAdjustmentValue;
            _calibrationValue = calibrationValue;

        }
    }
}
