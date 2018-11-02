using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class GraphList
    {
        public List<BloodPressure> graphList = new List<BloodPressure>();

        public GraphList(BloodPressure bloodPressure)
        {
            graphList.Add(bloodPressure);
        }
    }
}
