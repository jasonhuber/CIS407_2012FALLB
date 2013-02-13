using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FALL2012B
{
    public partial class securedpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(System.Web.HttpContext.Current.User.Identity.Name);
        }
    }
}