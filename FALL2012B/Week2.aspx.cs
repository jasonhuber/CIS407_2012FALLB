using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class Week2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["debug"] != "true")
            {
                pnlOutput.Visible = false;   
            }
            if (Request.Params["lastname"] != null)
            {
                txtLname.Text = Request.Params["lastname"];
            }
        }

        protected void cmdInput_Click(object sender, EventArgs e)
        {
            pnlOutput.Visible = true;
            pnlInput.Visible = false;

            txtOutput.Text = txtFname.Text + "\n" + txtLname.Text;
        }

        protected void btnRedo_Click(object sender, EventArgs e)
        {
            pnlOutput.Visible = false;
            pnlInput.Visible = true;

            foreach (Control item in Form.Controls)
            {
                if (item is ContentPlaceHolder)
                {
                    foreach (Control pnl in item.Controls)
                    {
                        if (pnl is Panel)
                        {
                            foreach (Control txt  in pnl.Controls)
                            {
                                if (txt is TextBox)
                                {
                                    ((TextBox)txt).Text = "";
                                }    
                            }
                            
                        }
                    }//end for each placeholder
                }
            }//end foreach controls (the upper most one)
            //this is only for Matthew
            ClientScript.RegisterClientScriptBlock(this.GetType(),"23","<script>alert('Matthew was here')</script>");
            
        }
    }
}