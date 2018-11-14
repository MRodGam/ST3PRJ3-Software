using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    interface IAlarmType
    {
        void RunAlarm();
        void MuteAlarm();
        void StopAlarm();
    }
}
