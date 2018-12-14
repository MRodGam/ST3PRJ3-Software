using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IZeroAdjustment
    {
        double GetZeroAdjustmentValue();
        //double ZeroAdjust(double rawData);
        bool IsMeasureRight();
        double GetLastValue();
    }
}
