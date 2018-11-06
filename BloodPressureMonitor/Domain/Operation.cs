using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Operation
    {
        public string Procedure { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double ZeroAdjustmentValue { get; set; }
        public double CalibrationValue { get; set; }


        public Operation(string procedure, DateTime startTime, DateTime endTime, double zeroAdjustmentValue, double calibrationValue)
        {
            Procedure = procedure;
            StartTime = startTime;
            EndTime = endTime;

            ZeroAdjustmentValue = zeroAdjustmentValue;
            CalibrationValue = calibrationValue;

        }
    }
}
