using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
**
** Sovellus hakee SQL Serverilta DemoxOy-tietokannasta lasnaolot-taulusta kaikki tietueet.
** Readeria kannattaa käyttää kun halutaan vain nopeasti lukea tulosjoukko kannasta esiin.
** Yksinkertainen käyttää, mutta ei kehittyneitä hakuja eikä liikkumista kannassa (menee aina järjestyksessä seuraavaan).
**
 */

namespace ADO_datareader
{
    public static class Program
    {
        static void Main(string[] args)
        {
            GetData_DataTable();
        }

        static void GetData_DataReader() { 
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                string connStr = @"Data source=eight.labranet.jamk.fi;"+
                                    "initial catalog=DemoxOy;"+
                                    "user=koodari;"+
                                    "password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // avataan yhteys
                    conn.Open();

                    // luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // luodaan reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            // käydään rdr läpi
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tietueita ei ole olemassa.");
                            }

                            // suljetaan rdr hyvän tavan mukaan
                            rdr.Close();
                        }
                    }

                    // suljetaan tietokantayhteys
                    conn.Close();
                    Console.WriteLine("Tietokantayhtyes suljettu.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hirvittava probleema!" + ex.Message);
            }
        }

        static void GetData_DataTable()
        {
            // UI-kerros datan esittämiseen
            try
            {
                // Haetaan data Datatablen avulla
                DataTable dt = GetDataReal();
                string rivi = "";

                // loopitetaan DataTablen rivit läpi
                // (Ei mene looppiin jos ei rivejä)
                foreach (DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach  (DataColumn dc in dt.Columns)
                    {
                        rivi += dr[dc].ToString();
                    }

                    Console.WriteLine(rivi);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static DataTable GetDataSimple()
        {
            //taulu
            DataTable dt = new DataTable();

            //sarakkeet
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            //rivit
            dt.Rows.Add("Kalle", "Kustaa");
            dt.Rows.Add("Matt", "Nickerson");

            return dt;
        }

        static DataTable GetDataReal()
        {
            // DBkerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet
            string connStr = @"Data source=eight.labranet.jamk.fi;" +
                                    "initial catalog=DemoxOy;" +
                                    "user=koodari;" +
                                    "password=koodari13";

            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                string connectionStr = @"Data source=eight.labranet.jamk.fi;" +
                                    "initial catalog=DemoxOy;" +
                                    "user=koodari;" +
                                    "password=koodari13";
                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    // avataan yhteys
                    conn.Open();

                    // luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
