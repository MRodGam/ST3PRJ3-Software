using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Alarm
    {
       public string Urgency { get; set; }
       public DateTime AlarmStartTime { get; set; }
       public DateTime AlarmEndTime { get; set; }

       public Alarm(string urgency, DateTime startTime, DateTime endTime)
       {
           Urgency = urgency;
           AlarmStartTime = startTime;
           AlarmEndTime = endTime;
       }


    }
}
