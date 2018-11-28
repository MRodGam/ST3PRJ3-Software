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


        public UC4M4_SaveData(ISave save, IData datalayer)
        {
            guiInterface = save;
            datalayerInterface = datalayer;
        }

        public void SaveDataLogic(string IDno, string Procedure, string CPRno, DateTime timeAndDate, byte[] bloodpressureList, double Calibrate)
        {
            datalayerInterface.SaveInDatabase(IDno, Procedure, CPRno, timeAndDate, bloodpressureList, Calibrate);
        }


    }
}

