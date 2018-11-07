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
    class UC4M4_SaveData : ISave
    {
        private SqlConnection connectionP;
        private SqlConnection connectionO;
        private SqlDataReader reader;
        private SqlCommand command;
        private const String DBlogin = "F18ST2ITS2201710472"; //Husk at ændre navn her
        public List<CompletedMeasurement> GetCompletedMeasurement; //omdøb evt.

        public UC4M4_SaveData()
        {
            connectionP = new SqlConnection("Data Source=st-i4dab.E18ST3PRJ3Gr3.dbo;Initial Catalog=" + DBlogin +
                                            ";Persist Security Info=True;User ID=" + DBlogin + ";Password=" + DBlogin + "");
            connectionO = new SqlConnection(
                @"Data Source=i4dab.ase.au.dk;Initial Catalog=F18ST2PRJ2OffEKGDatabase;Integrated Security=False;User ID=F18ST2PRJ2OffEKGDatabase;Password=F18ST2PRJ2OffEKGDatabase;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

        }

        public List<dataList> GetCompletedMeasurement(string which)
        {
            BinaryFormatter bf = new BinaryFormatter();

            List<dataList> ListeOverMålinger = new List<dataList>(); //omdøb den samlede liste 


            string a = "SELECT * FROM GemPrivat" + which;
            //Oprette SQL kommando
            command = new SqlCommand("SELECT * FROM Gem" + which, connectionP);

            //Åbne DB-forbindelsen
            connectionP.Open();

            //Udføre det ønskede SQL statement på DB
            reader = command.ExecuteReader(); // nu indeholder rdr-objektet resultatet af forespørgslen

            while (reader.Read())
            {

                byte[] m = (byte[])(reader["MålingsListe"]);

                using (MemoryStream ms = new MemoryStream(m))
                {
                    bloodPressure = (List<Måling>)bf.Deserialize(ms);

                }

                //omdøb Gemtmåling
                GemtMåling måling = new GemtMåling(Convert.ToString(reader["CPRno"]), Convert.ToString(reader["IDno"]),
                    Convert.ToDateTime(reader["tidsstempel_"]), bloodPressure, Convert.ToInt32(reader["Puls"]), Convert.ToInt32(reader["Systolic"]), Convert.ToInt32(reader["Diastolic"]), Convert.ToInt32(reader["Mean"]));
                GetCompletedMeasurement.Add(måling);

            }

            //Lukke forbindelsen til DB
            connectionP.Close();

            return GetCompletedMeasurement;
        }

        public void SaveInDatabase(string CPRno, string IDno, DateTime date, byte[] GetCompletedMeasurement, int Systolic, int Diastolic, int Mean, int Puls)
        {


            connectionP.Open();
            SqlCommand command_ = new SqlCommand("INSERT INTO SaveInDatabase(IDno, CPRno, tidsstempel_, GetCompletedMeasurement, Systolic, Diastolic, Mean, Puls) VALUES(@IDno, @CPRno, @tidsstempel_, @GetCompletedMeasurement, @Systolic, @Diastolic, @Puls)", connectionP);
            command_.Parameters.AddWithValue("@IDno", IDno);
            command_.Parameters.AddWithValue("@CPRno", CPRno);
            command_.Parameters.AddWithValue("@tidsstempel_", date);
            command_.Parameters.AddWithValue("@GetCompletedMeasurement", måling);
            command_.Parameters.AddWithValue("@Systolic", måling);
            command_.Parameters.AddWithValue("@Diastolic", måling);
            command_.Parameters.AddWithValue("@Mean", måling);
            command_.Parameters.AddWithValue("@Puls", Puls);

            command_.ExecuteNonQuery();
            connectionP.Close();

        }

    }
}
}
