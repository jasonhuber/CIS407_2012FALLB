using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class Week1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblResult.Text = (int.Parse(txtNum1.Text) + int.Parse(txtNum2.Text)).ToString();
        }
    }
}