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
        private const String DBlogin = "E18ST3PRJ3Gr3";
        public List<double> bloodPressureList;
        private double calibrateDatabaseValue;
        public List<double> GetCompletedMeasurement { get; private set; }

        public double a { get; private set; }
        public double b { get; private set; }

        public Database() //st-i4da.
        {
            connectionP = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=E18ST3PRJ3Gr3;Persist Security Info=True;User ID=E18ST3PRJ3Gr3;Password=E18ST3PRJ3Gr3");
            

        }

        private static byte[] GetBytes(List<double> dataList)
        {
            if (dataList == null) return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, dataList);
            return ms.ToArray();
        }

        public List<double> rawData(string which)
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
                    bloodPressureList = (List<double>)bf.Deserialize(ms);
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

        public void SaveInDatabase(string IDno, string Procedure, string CPRno, string Name, DateTime timeAndDate, List<double> bloodPressureList) //,    
        {
            connectionP.Open();
            SqlCommand command_ = new SqlCommand("INSERT INTO SaveInDatabase(Idno, Procedures, CPRno, Name, timeAndDate, CompletedMeasurement) VALUES(@Idno, @Procedure, @CPRno, @Name, @timeAndDate, @CompletedMeasurement)", connectionP);
            command_.Parameters.AddWithValue("@Idno", IDno);
            command_.Parameters.AddWithValue("@Procedure", Procedure);
            command_.Parameters.AddWithValue("@CPRno", CPRno);
            command_.Parameters.AddWithValue("@Name", Name);
            command_.Parameters.AddWithValue("@timeAndDate", timeAndDate);
            command_.Parameters.AddWithValue("@CompletedMeasurement", GetBytes(bloodPressureList));
            command_.ExecuteNonQuery();
            connectionP.Close();
        }

        public CalibrationValue GetCalibrateValue() //henter kalibreringværdi
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Calibrate", connectionP);
            connectionP.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                command.CommandText = "SELECT * FROM Calibrate  where calibrateA=@CalibrateA";
                a = Convert.ToDouble(reader["CalibrateA"]);
                command.CommandText = "SELECT * FROM Calibrate where calibrateB=@CalibrateB";
                b = Convert.ToDouble(reader["CalibrateB"]);
            }

            CalibrationValue calibrationValue = new CalibrationValue(a, b);
            return calibrationValue;
        }

        public void SaveCalibrateValue(CalibrationValue calibrationValue) //gemmer kalibreringsværdi
        {
            //skal gemme clibrate-værdi
            connectionP.Open();
            SqlCommand command_ = new SqlCommand("INSERT INTO Calibrate (Idnr, CalibrateA, CalibrateB) VALUES(@Idnr, @CalibrateA, @CalibrateB)", connectionP);
            command_.Parameters.AddWithValue("@Idnr", "Admin");
            command_.Parameters.AddWithValue("@CalibrateA", calibrationValue._a);
            command_.Parameters.AddWithValue("@CalibrateB", calibrationValue._b);
            command_.ExecuteNonQuery();
            connectionP.Close();
        }
    }
}
