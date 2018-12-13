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
            List<double> bloodpressureList);
        

        List<double> rawData(string which);

        CalibrationValue GetCalibrateValue();
        void SaveCalibrateValue(CalibrationValue calibrationValue);


        //List<RawData> GetCompletedMeasurement { get; private set; }
    }
}
