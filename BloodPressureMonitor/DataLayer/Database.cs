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
using System.Net.Mail;
using System.Data;

namespace DataLayer
{
    public class Database : IData
    {
        private SqlConnection connectionP;
        private SqlDataReader reader;
        private SqlCommand command;
        private const String DBlogin = "st-i4dab.E18ST3PRJ3Gr3";
        private List<RawData> bloodPressureList;
        private double calibrateDatabaseValue;
        public List<RawData> GetCompletedMeasurement { get; private set; }

        public Database()
        {
            connectionP = new SqlConnection("Data Source=st-i4dab.E18ST3PRJ3Gr3.dbo;Initial Catalog=" + DBlogin +
                                            ";Persist Security Info=True;User ID=" + DBlogin + ";Password=" + DBlogin + "");

           
        }

        public List<RawData> rawData(string which)
        {
            BinaryFormatter bf = new BinaryFormatter();

            List<SaveData> SaveData_ = new List<SaveData>();

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

                //Data skrives til domain klasse SaveData
                 SaveData saveData = new SaveData(Convert.ToString(reader["CPRno"]), Convert.ToString(reader["Idno"]),
                    Convert.ToString(reader["Procedure"]), 
                    Convert.ToString(reader["Name"]),
                    Convert.ToDateTime(reader["timeAndDate"]), bloodPressureList);
                //Convert.ToDouble(reader["Calibrate"]));
                SaveData_.Add(saveData);
            }

            //Lukke forbindelsen til DB
            connectionP.Close();
            return GetCompletedMeasurement;
        }

        public void SaveInDatabase(string IDno, string Procedure, string CPRno, string Name, DateTime timeAndDate, List<RawData> bloodpressureList)
        {
            connectionP.Open();
            SqlCommand command_ = new SqlCommand("INSERT INTO SaveInDatabase(IDno, Procedure, CPRno, Name, timeAndDate, CompletedMeasurement) VALUES(@IDno, @Procedure, @CPRno, @Name, @timeAndDate, @CompletedMeasurement)", connectionP);
            command_.Parameters.AddWithValue("@IDno", IDno);
            command_.Parameters.AddWithValue("@Procedure", Procedure);
            command_.Parameters.AddWithValue("@CPRno", CPRno);
            command_.Parameters.AddWithValue("@timeAndDate", timeAndDate);
            command_.Parameters.AddWithValue("@getCompletedMeasurement", bloodPressureList);
            command_.ExecuteNonQuery();
            connectionP.Close();
        }

        public double GetCalibrateValue() //henter kalibreringværdi
        {
            command.CommandText = "select * from Calibrate where calibrate=@Calibrate";
            command.Parameters.Add("Calibrate",SqlDbType.VarChar).Value = calibrateDatabaseValue;
            connectionP.Open();
            SqlDataReader reader = command.ExecuteReader();
            return calibrateDatabaseValue;
        }

        public void SaveCalibrateValue(double Calibrate) //gemmer kalibreringsværdi
        {
            //skal gemme clibrate-værdi
            connectionP.Open(); //hvad sker der her? 
            SqlCommand command_ = new SqlCommand("INSERT INTO SaveCalibrateValue (Calibrate) VALUES(@Calibrate)"), connectionP;
            command_.Parameters.AddWithValue("@Calibrate", Calibrate);
            command_.ExecuteNonQuery();
            connectionP.Close();
        }
    }
}
