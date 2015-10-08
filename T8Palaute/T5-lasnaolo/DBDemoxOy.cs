using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public static class DBDemoxOy
    {
        public static DataTable GetDataSimple()
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

        public static DataTable GetDataReal(string asioid = "")
        {
            // DBkerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet 

            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                string connectionStr = @"Data source=eight.labranet.jamk.fi;" +
                                    "initial catalog=DemoxOy;" +
                                    "user=koodari;" +
                                    "password=koodari13";

                if (asioid != "")
                {
                    sql += " WHERE asioid = '" + asioid + "'";
                    
                }

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
