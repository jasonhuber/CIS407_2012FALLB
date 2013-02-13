using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void cmdLogIn_Click(object sender, EventArgs e)
        {
            ////web config method
            //if (System.Web.Security.FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            //{
            //    //good you logged in.
            //    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            //}
            //else
            //{
            //    lblError.Text = "Either your username or password was incorrect";
            //    lblError.Visible = true;
            //}
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["HuberTrackerConnection"].ToString();
            conn.ConnectionString = connectionstring;
            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string sql = "select userlevel from huber_logon where userid = @userid and password = @password";

            comm.CommandText = sql;

            comm.Parameters.AddWithValue("@userid", txtUserName.Text);
            comm.Parameters.AddWithValue("@password", txtPassword.Text);

            object result = comm.ExecuteScalar();
            if (result != null)
            {
                //send them where i choose:

                System.Web.Security.FormsAuthentication.SetAuthCookie(txtUserName.Text, false);
                Response.Redirect("Week4.aspx");

                //send them where they tried to go:
                //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
            else
            {
                lblError.Text = "Either your username or password was incorrect";
            }

            conn.Close();
        }
    }
}