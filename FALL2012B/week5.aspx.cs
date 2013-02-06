using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class week5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Databaser.DatabaseObject mydbobj = new Databaser.DatabaseObject();
            mydbobj.UpdateDBSimple("update huber_accounts set balance = 2000 where accountid = 1", System.Configuration.ConfigurationManager.ConnectionStrings[2].ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
           lblBalance.Text = ProcessCheck(double.Parse(txtCheck1.Text)).ToString();
           lblBalance.Text = ProcessCheck(double.Parse(txtCheck2.Text)).ToString();
           lblBalance.Text = ProcessCheck(double.Parse(txtCheck3.Text)).ToString();
           lblBalance.Text = ProcessCheck(double.Parse(txtCheck4.Text)).ToString();
           lblBalance.Text = ProcessCheck(double.Parse(txtCheck5.Text)).ToString();
        }


        public double ProcessCheck(double value)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["HuberTrackerConnection"].ToString();
            conn.ConnectionString = connectionstring;
            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            System.Data.SqlClient.SqlTransaction trans;
            trans = conn.BeginTransaction();
            comm.Transaction = trans;

            string sql = "update huber_accounts set balance = balance - @balance where accountid = 1";

            comm.CommandText = sql;
            comm.Parameters.AddWithValue("@balance", value);

            comm.ExecuteNonQuery();

            sql = "select balance from huber_accounts where accountid = 1";

            comm.Parameters.Clear();
            comm.CommandText = sql;
            object result = comm.ExecuteScalar();
            
            if (Convert.ToDouble(result) < .01)
	        {
                trans.Rollback();
                conn.Close();
		       
	        }
            else
            {
                trans.Commit();
                conn.Close();
              
            }
            return Convert.ToDouble(result);
        }
        //private void UpdateDB(string sql)
        //{ 
        //         System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        //    string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings[2].ToString();
        //    conn.ConnectionString = connectionstring;
        //    conn.Open();
        //    // Console.WriteLine(conn.State);
        //    System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
        //    comm.Connection = conn;
           
        //    comm.CommandText = sql;
        //    comm.ExecuteNonQuery();
        //    conn.Close();
        
        //}
    }
}