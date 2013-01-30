using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string item in Request.ServerVariables)
            {
                if (Request.ServerVariables[item].Length > 1)
                {
                    DoallThetracking(item, Request.ServerVariables[item]);
                }
            }
            //DoallThetracking("IP", Request.ServerVariables["REMOTE_ADDR"]);
            //DoallThetracking("UA", Request.ServerVariables["HTTP_USER_AGENT"]);
        }

        private void DoallThetracking(string trackkey, string value)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = "Server=devrystudentsp10.db.6077598.hostedresource.com;User Id=DeVryStudentSP10;Password=OidLZqBv4;";
            conn.Open();
            // Console.WriteLine(conn.State);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string SQL = "insert into huber_tracker12 (usertrackerid, trackkey, value,trackwhen) values (NEWID(), @trackkey, @trackvalue, @trackwhen)";

            comm.CommandText = SQL;

            comm.Parameters.AddWithValue("@trackkey", trackkey);
            comm.Parameters.AddWithValue("@trackvalue", value);
            comm.Parameters.AddWithValue("@trackwhen", DateTime.Now);

            comm.ExecuteNonQuery();

            SQL = "delete from huber_tracker12 where usertrackerid not in (select top 300 usertrackerid from huber_tracker12 order by trackwhen desc)";
                comm.CommandText = SQL;
            comm.ExecuteNonQuery();

        }
    }
}
