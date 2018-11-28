using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public interface ISave
    {
        void SaveDataLogic(string IDno, string Procedure, string CPRno, DateTime timeAndDate, byte[] bloodpressureList, double Calibrate);
    }
}
