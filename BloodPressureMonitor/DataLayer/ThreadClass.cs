using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DataLayer
{
    class ThreadClass
    {
        // Opretter tråd
        // Producer og consumer metoden
        // Sørger for at rådataobjekterne kan blive transporteret fra den ene ende til den anden

        public DAQ localDAQ;
        public Thread pushThread;

        public ThreadClass(DAQ actualDAQ)
        {
            localDAQ = actualDAQ;
            pushThread = new Thread(localDAQ.CollectData);
        }

         

    }
}
