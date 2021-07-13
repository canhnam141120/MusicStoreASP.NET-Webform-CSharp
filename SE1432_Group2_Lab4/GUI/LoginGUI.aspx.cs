using SE1432_Group2_Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassworld.Text;

            if (UserDAO.Instance.Login(username, password))
            {
                object role = DAO.GetData(new SqlCommand("SELECT Role From Users Where UserName = '" + username + "'"));
                Session["username"] = username;
                Session["role"] = role;
                if (Session["ShoppingCartID"] != null)
                {
                    CartDAO.MigrateCart(Session["ShoppingCartID"].ToString(), Session["username"].ToString());

                    SqlCommand cmd3 = new SqlCommand("SELECT SUM(Count) FROM Carts WHERE CartId ='" + Session["username"] + "'");
                    object a = DAO.GetData(cmd3);
                    if (a.ToString() == null || a.ToString() == "")
                    {
                        Session["CountCart"] = 0;
                    }
                    else
                    {
                        int TotalCount = int.Parse(a.ToString());
                        Session["CountCart"] = TotalCount;
                    }
                }
                Response.Redirect("/GUI/ShoppingGUI.aspx");
            }
            else { lbThongbao.Text = "Tài khoản hoặc Mật khẩu không chính xác!"; }
        }
    }
}