using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class SaveData
    {
        private string CPRno_;
        private string Idno_;
        private string procedure_;
        private string name_;
        private string timeAndDate_;
        private List<RawData> completedMeasurement_;
        private int mean_;
        private int pulse_;
        private double calibrate_;

        public SaveData(string CPRno, string Idno, string procedure, string name,
            DateTime timeAndDate, List<RawData> completedMeasurement, int mean, int pulse, double calibrate)
        {
            CPRno_ = CPRno;
            Idno_ = Idno;
            procedure_ = procedure;
            name_ = name;
            timeAndDate_ = timeAndDate.Date.ToString("MM/dd/yyyy");
            completedMeasurement_ = completedMeasurement;
            calibrate_ = calibrate;
        }

        public SaveData()
        {CPRno_ = "None";}

        public string getCPRno()
        {return CPRno_;}

        public string getIdno()
        {return Idno_;}

        public string getProcedure()
        {return procedure_;}

        public string getName()
        {return name_;}

        public double getCalibration()
        {return calibrate_;}


    }
}
