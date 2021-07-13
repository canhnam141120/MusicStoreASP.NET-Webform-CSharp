using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderid = int.Parse(Request.QueryString["orderid"]);
            Label1.Text = "Order " + orderid + " is saved!";
        }
    }
}