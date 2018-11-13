using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Domain;

namespace LogicLayer
{
    class LogicThreadClass
    {
        //Manages the pull thread.

        public DataTreatment localDataTreament;
        public Thread pullThread;

        public LogicThreadClass(DataTreatment actualDataTreatment)
        {
            localDataTreament = actualDataTreatment;
            pullThread = new Thread(localDataTreament.TreatData);
        }

        public void StartTreatment()
        {
            pullThread.Start();
        }
    }
}
