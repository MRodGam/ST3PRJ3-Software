using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataLayer
{
    public interface IData
    {
        void SaveInDatabase(string IDno, string Procedure, string CPRno, DateTime timeAndDate,
            byte[] bloodpressureList, double Calibrate);

        List<RawData> rawData(string which);

        //List<RawData> GetCompletedMeasurement { get; private set; }
    }
}
