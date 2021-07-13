using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {

                    Button1.Text = "Logout(" + Session["username"].ToString() + ")";
                    if ((int)Session["role"] == 1)
                    {
                        HReport.Visible = true;
                        HAlbum.Visible = true;
                    }
                }
                else
                {
                    Button1.Text = "Login";
                }
                if (Session["CountCart"] != null)
                {
                    HCart.Text = "Cart(" + Session["CountCart"] + ")";
                }
                else
                {
                    HCart.Text = "Cart(0)";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Session["CountCart"] = 0;
                Session["username"] = null;
                Response.Redirect("/GUI/GoodByeGUI.aspx");
            }
            else
            {
                Response.Redirect("/GUI/LoginGUI.aspx");
            }
            
        }
    }
}