using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public interface IFilter
    {
        //Skal slettes :-) 

        void StartFilter();
        void StopFilter();
        void FilterData();
        List<RawData> GetFilterData();
    }
}
