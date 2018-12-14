using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public interface ICalibrate
    {
        // de to metoder som skal kunne kaldes andet sted fra
        void AddVoltageValue(int pressureValue);
        void DoCalibrateRegression();

        bool GetIsAll5MeasureDone();

        CalibrationValue getCalibrateValue();
        string updateCalibrateText();
    }
}
