using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databaser
{
    public class DatabaseObject
    {
        public void UpdateDBSimple(string sql, string connectionstring)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            //string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
            conn.ConnectionString = connectionstring;
            conn.Open();
            // Console.WriteLine(conn.State);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            comm.CommandText = sql;
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
