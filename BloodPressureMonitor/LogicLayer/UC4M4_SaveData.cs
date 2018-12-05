using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SqlClient;
using DataLayer;
using Domain;

namespace LogicLayer
{
    public class UC4M4_SaveData : ISave
    {
        private ISave guiInterface;
        private IData datalayerInterface;
        private CalibrationValue value_;
        private DataTreatment dataTreatment_;

     
        public UC4M4_SaveData(ISave save, IData datalayer, CalibrationValue value, DataTreatment data)
        {
            dataTreatment_ = data;
            guiInterface = save;
            datalayerInterface = datalayer;
            value_ = value;
        }

        public CalibrationValue Calibrate { get; private set; }

        public void SaveDataLogic(string IDno, string Procedure, string CPRno, string name, DateTime timeAndDate) //, byte[] bloodpressureList, double Calibrate) //
        {
            //bloodpressureList = new List<TotalRawList>(); //skal gemme den totale RawList 
            datalayerInterface.SaveInDatabase(IDno, Procedure, CPRno, name, timeAndDate, dataTreatment_.GetFullList(), value_.Value  ); // Lav GetFullList i datatreatment
        }


    }
}

