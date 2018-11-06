using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Log
    {
        public int SocSecNumber { get; set; }
        public string Procedure { get; set; }
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AlarmCounter { get; set; }

        public Log(int socSecNumber, string procedure, int id, DateTime startTime, DateTime endTime, int alarmCounter)
        {
            SocSecNumber = socSecNumber;
            Procedure = procedure;
            StartTime = startTime;
            EndTime = endTime;
            AlarmCounter = alarmCounter;


        }

    }
}
