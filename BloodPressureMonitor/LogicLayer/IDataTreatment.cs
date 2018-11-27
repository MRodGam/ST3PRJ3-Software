using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public interface IDataTreatment
    {
        void StartGraphData();
        void StopGraphData();
        void GetRawData();
        void MakeShortRawList();
        List<ConvertedData> GetGraphList();
        List<RawData> GetFilterList();
    }
}
