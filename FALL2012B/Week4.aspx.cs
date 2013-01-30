using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class Week4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//            if (!IsPostBack)
//            {
                
            
//                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
//                conn.ConnectionString = "Server=devrystudentsp10.db.6077598.hostedresource.com;User Id=DeVryStudentSP10;Password=OidLZqBv4;";
//                conn.Open();
//                // Console.WriteLine(conn.State);
//                System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
//                comm.Connection = conn;

//                string SQL = "select top 100 usertrackerid, trackkey, value,trackwhen from huber_tracker12 order by trackwhen";

           
//                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
//                comm.CommandText = SQL;

//                                            #region "Dataset"
//            //this is a dataset
//            // System.Data.DataSet ds = new System.Data.DataSet();
//            //da.SelectCommand = comm;
//            //da.Fill(ds);
//            //this is a dataset
//            //rptDisplay.DataSource = ds.Tables[0];
//#endregion

//                System.Data.SqlClient.SqlDataReader dr;
//                dr = comm.ExecuteReader();

//                if (dr.HasRows)
//                {
//                    rptDisplay.DataSource = dr;
//                    rptDisplay.DataBind();
//                }
//                }
            rptDisplay.ViewStateMode = System.Web.UI.ViewStateMode.Disabled;
        }

        protected void cmdSearch_OnClick(object source, EventArgs e)
        {

            try
            {

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = "Server=devrystudentsp10.db.6077598.hostedresource.com;User Id=DeVryStudentSP10;Password=OidLZqBv4;";
                conn.Open();
                // Console.WriteLine(conn.State);
                System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
                comm.Connection = conn;

                string SQL = "select usertrackerid, trackkey, value,trackwhen from huber_tracker12 where 1=1";
                if (txtKey.Text.Length > 0)
                {
                    SQL += " and trackkey like @trackkey";
                    comm.Parameters.AddWithValue("@trackkey", "%" + txtKey.Text + "%");
                }
                if (txtValue.Text.Length > 0)
                {
                    SQL += " and value like @value ";
                    comm.Parameters.AddWithValue("@value", "%" + txtValue.Text + "%");
                }
                Response.Write(SQL);
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                comm.CommandText = SQL;



                #region "Dataset"
                //this is a dataset
                // System.Data.DataSet ds = new System.Data.DataSet();
                //da.SelectCommand = comm;
                //da.Fill(ds);
                //this is a dataset
                //rptDisplay.DataSource = ds.Tables[0];
                #endregion

                System.Data.SqlClient.SqlDataReader dr;
                dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    rptDisplay.DataSource = dr;
                    rptDisplay.DataBind();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                //throw new would go with the changes to your web.config
                //throw new Exception("Connecting to DB", sqlex.InnerException);

                //this way is "roll your own"
                Response.Redirect("anerrorpage.aspx?msg=Error Connecting To DB");
            }
            catch (Exception ex)
            {
                Response.Write("error!");

            }

                }
        }

      

     
    }
