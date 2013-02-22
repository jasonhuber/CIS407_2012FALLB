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
            if (Session["UserLevel"] == null ||  Session["UserLevel"].ToString() != "Admin")
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
                sql = "insert into huber_logon (userid, password, firstname, lastname, email) values (@userid, @password, @firstname, @lastname, @email)";
                comm.CommandText = sql;
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@userid", txtUserName.Text);
                comm.Parameters.AddWithValue("@password", txtPassword.Text);
                comm.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                comm.Parameters.AddWithValue("@lastname", txtLastName.Text);
                comm.Parameters.AddWithValue("@email", txtEmail.Text);

                int numrowsaffected;
                numrowsaffected = comm.ExecuteNonQuery();
                if (numrowsaffected == 1)
                {
                  //  lblError.Text = "User Added!";
                    lblError.Visible = true;
                    ClearFields();
                   lblError.Text =  EmailThatUser(txtEmail.Text);
                   lblError.Text += "cockroach";
                }
                else
                {
                    lblError.Text = "There was a problem with the user!";
                    lblError.Visible = true;   
                }
               }
            conn.Close();
        }

        private string EmailThatUser(string emailTo)
        {
            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(
                    "admin@hub3r.com", emailTo, "Your user account at Hub3r.com", @"You can login at http://hub3r.com/jasonhuber/login.aspx");
            System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtpout.secureserver.net");
            SMTPServer.Credentials = new System.Net.NetworkCredential("devryspam@hub3r.com", "ILuvD3Vry");
            //SMTPServer.EnableSsl = true;
            try
            {
                SMTPServer.Send(mm);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "Email sent!";
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