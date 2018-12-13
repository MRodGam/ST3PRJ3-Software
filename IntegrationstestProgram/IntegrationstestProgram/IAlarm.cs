using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IAlarm
    {
        void ControlAlarm();
        bool GetIsAlarmRunning();
        void StopAlarm();
        void StartAlarm();

        //void MuteAlarm();
        //bool GetIsAlarmActive();

    }
}
