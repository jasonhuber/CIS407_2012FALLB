using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLevel"] == null ||  Session["UserLevel"] != "Admin")
            {
                Response.Redirect("default.aspx");
                Response.End();
            }
        }

        protected void cmdAddUser_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["HuberTrackerConnection"].ToString();
            conn.ConnectionString = connectionstring;
            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string sql = "select userid from huber_logon where userid = @userid";

            comm.CommandText = sql;

            comm.Parameters.AddWithValue("@userid", txtUserName.Text);
          
            object result = comm.ExecuteScalar();
            if (result != null)
            {
              //that userid exists! ABORT! (and tell the user)
                lblError.Text = "That username is already in use.";
                lblError.Visible = true;

            }
            else
            {
                sql = "insert into huber_logon (userid, password, firstname, lastname) values (@userid, @password, @firstname, @lastname)";
                comm.CommandText = sql;
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@userid", txtUserName.Text);
                comm.Parameters.AddWithValue("@password", txtPassword.Text);
                comm.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                comm.Parameters.AddWithValue("@lastname", txtLastName.Text);

                comm.ExecuteNonQuery();
                lblError.Text = "User Added!";
                lblError.Visible = true;
                ClearFields();
            }
            conn.Close();
        }

        public void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
        }
    }
}