using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace LogicLayer
{
    class Observer
    {
        private List<IDataTreatment> _observers = new List<IDataTreatment>();

        public void Attach(IDataTreatment observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IDataTreatment observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }


        public void StartGraphData()
        {
            throw new NotImplementedException();
        }

        public void StopGraphData()
        {
            throw new NotImplementedException();
        }

        public void GetRawData()
        {
            throw new NotImplementedException();
        }

        public void MakeShortRawList()
        {
            throw new NotImplementedException();
        }

        public List<ConvertedData> GetGraphList()
        {
            throw new NotImplementedException();
        }

        public List<RawData> GetFilterList()
        {
            throw new NotImplementedException();
        }

        public void StartFilter()
        {
            throw new NotImplementedException();
        }

        public void StopFilter()
        {
            throw new NotImplementedException();
        }

        public void FilterData()
        {
            throw new NotImplementedException();
        }

        public List<RawData> GetFilterData()
        {
            throw new NotImplementedException();
        }
    }
}
