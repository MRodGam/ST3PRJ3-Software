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
        void SaveInDatabase(string IDno, string Procedure, string CPRno, string Name,  DateTime timeAndDate,
            List<RawData> bloodpressureList);
        

        List<RawData> rawData(string which);

        CalibrationValue GetCalibrateValue(CalibrationValue calibrationValue);
        void SaveCalibrateValue(CalibrationValue calibrationValue);


        //List<RawData> GetCompletedMeasurement { get; private set; }
    }
}
