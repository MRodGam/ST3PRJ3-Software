using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TotalMeasurementsLists
    {
        public List<BloodPressure> TotalRawList = new List<BloodPressure>();
        public List<BloodPressure> TotalConvertedList = new List<BloodPressure>();
        public List<BloodPressure> TotalFilteredList = new List<BloodPressure>();

        public TotalMeasurementsLists(BloodPressure rawData, BloodPressure convertedData, BloodPressure filteredData)
        {
            TotalRawList.Add(rawData);
            TotalConvertedList.Add(convertedData);
            TotalFilteredList.Add(convertedData);
        }
    }
}
