using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;
using DataLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Domain;

namespace DataLayer
{
    class Database : IData
    {
        private SqlConnection connectionP;
        private SqlDataReader reader;
        private SqlCommand command;
        private const String DBlogin = "st-i4dab.E18ST3PRJ3Gr3";
        private List<RawData> bloodPressureList;
        public List<RawData> GetCompletedMeasurement { get; private set; }

        public Database()
        {
            connectionP = new SqlConnection("Data Source=st-i4dab.E18ST3PRJ3Gr3.dbo;Initial Catalog=" + DBlogin +
                                            ";Persist Security Info=True;User ID=" + DBlogin + ";Password=" + DBlogin + "");
        }

        public List<RawData> rawData(string which)
        {
            BinaryFormatter bf = new BinaryFormatter();

            List<RawData> rawData = new List<RawData>(); 

            string a = "SELECT * FROM SaveData" + which;
            //Oprette SQL kommando
            command = new SqlCommand("SELECT * FROM SaveData" + which, connectionP);

            //Åbne DB-forbindelsen
            connectionP.Open();

            //Udføre det ønskede SQL statement på DB
            reader = command.ExecuteReader(); // nu indeholder rdr-objektet resultatet af forespørgslen

            while (reader.Read())
            {
                byte[] m = (byte[])(reader["MeasurementList"]);

                using (MemoryStream ms = new MemoryStream(m))
                {
                    bloodPressureList = (List<RawData>)bf.Deserialize(ms);
                }

                //omdøb Gemtmåling
                SaveData saveData = new SaveData(Convert.ToString(reader["Idno"]), Convert.ToString(reader["Procedure"]), Convert.ToString(reader["CPRno"]), Convert.ToString(reader["Name"]),
                    Convert.ToDateTime(reader["timeAndDate"]), bloodPressureList, Convert.ToDouble(reader["Calibrate"]));
                GetCompletedMeasurement.Add(saveData);
            }

            //Lukke forbindelsen til DB
            connectionP.Close();
            return GetCompletedMeasurement;
        }

        public void SaveInDatabase(string IDno, string Procedure, string CPRno, DateTime timeAndDate, byte[] bloodpressureList, double Calibrate)
        {
            connectionP.Open();
            SqlCommand command_ = new SqlCommand("INSERT INTO SaveInDatabase(IDno, Procedure, CPRno, Name, timeAndDate, CompletedMeasurement, Calibrate) VALUES(@IDno, @Procedure, @CPRno, @Name, @timeAndDate, @CompletedMeasurement, @Calibrate)", connectionP);
            command_.Parameters.AddWithValue("@IDno", IDno);
            command_.Parameters.AddWithValue("@Procedure", Procedure);
            command_.Parameters.AddWithValue("@CPRno", CPRno);
            command_.Parameters.AddWithValue("@timeAndDate", timeAndDate);
            command_.Parameters.AddWithValue("@getCompletedMeasurement", bloodPressureList);
            command_.Parameters.AddWithValue("@Calibrate", Calibrate);
            command_.ExecuteNonQuery();
            connectionP.Close();
        }
    }
}
