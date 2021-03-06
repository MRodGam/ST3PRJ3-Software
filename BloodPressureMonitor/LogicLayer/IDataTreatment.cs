﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    public interface IDataTreatment // evt slette denne klasse. Da den lige nu ligger mellem Subjet og den konkrete sunbjet (DataTreatment)
    {
        void StartGraphData();
        void StopGraphData();
        void MakeShortRawList();
        List<ConvertedData> GetGraphList();
        List<RawData> GetFilterList();
        

        //Filter
        void StartFilter();
        void StopFilter();
        void FilterData();
        List<RawData> GetFilterData(); 
    }
}
