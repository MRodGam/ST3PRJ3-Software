using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IAlarm
    {
        void PlayAlarm();
        void MuteAlarm();
        void StopAlarm();
        bool GetIsAlarmActive();
    }
}
