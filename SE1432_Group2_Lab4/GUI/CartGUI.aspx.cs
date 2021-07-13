using SE1432_Group2_Lab4.DAL;
using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                LoadCart();
            }
            else
            {
                LoadCartUser();
            }
            if (ListView1.Items.Count == 0)
            {
                btnCheckout.Enabled = false;
                btnCheckout.BackColor = Color.Gray;
                Label1.Visible = true;
                lbTotal.Text = "0.00";
            }
        }

        public void LoadCart()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(PRICE*Count) FROM Albums inner join Carts on Albums.AlbumId = Carts.AlbumId WHERE Carts.CartId ='" + Session["ShoppingCartID"] + "'");
            object Total = DAO.GetData(cmd);
            lbTotal.Text = Total.ToString();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Carts WHERE CartId ='" + Session["ShoppingCartID"] + "'");
            ListView1.DataSource = DAO.GetDataTable(cmd2);
            ListView1.DataBind();
            if (ShoppingCartDAO.ShoppingCartId != null)
            {
                SqlCommand cmd3 = new SqlCommand("SELECT SUM(Count) FROM Carts WHERE CartId ='" + Session["ShoppingCartID"] + "'");
                if (ListView1.Items.Count == 0)
                {
                    int TotalCount1 = 0;
                    Session["CountCart"] = TotalCount1;
                }
                if (ListView1.Items.Count > 0)
                {
                    int TotalCount = int.Parse(DAO.GetData(cmd3).ToString());
                    Session["CountCart"] = TotalCount;
                }
            }
        }
        public void LoadCartUser()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(PRICE*Count) FROM Albums inner join Carts on Albums.AlbumId = Carts.AlbumId WHERE Carts.CartId ='" + Session["username"] + "'");
            object Total = DAO.GetData(cmd);
            lbTotal.Text = Total.ToString();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Carts WHERE CartId ='" + Session["username"] + "'");
            ListView1.DataSource = DAO.GetDataTable(cmd2);
            ListView1.DataBind();
            SqlCommand cmd3 = new SqlCommand("SELECT SUM(Count) FROM Carts WHERE CartId ='" + Session["username"] + "'");
            if (ListView1.Items.Count == 0)
            {
                int TotalCount1 = 0;
                Session["CountCart"] = TotalCount1;
            }
            if (ListView1.Items.Count > 0)
            {
                int TotalCount = int.Parse(DAO.GetData(cmd3).ToString());
                Session["CountCart"] = TotalCount;
            }
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Session["totalCart"] = lbTotal.Text;


            List<OrderDetail> ods = new List<OrderDetail>();
            DataTable dt = new DataTable();
            dt = (DataTable)ListView1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderDetail o = new OrderDetail();
                o.AlbumID = int.Parse(dt.Rows[i]["AlbumId"].ToString());
                o.Quantity = int.Parse(dt.Rows[i]["Count"].ToString());
                SqlCommand cmd = new SqlCommand("SELECT PRICE FROM Albums WHERE AlbumId =" + o.AlbumID);
                o.UnitPrice = double.Parse(DAO.GetData(cmd).ToString());
                ods.Add(o);
            }
            Session["Cart"] = ods;
            Response.Redirect("/GUI/CheckoutGUI.aspx");
        }

        protected void RemoveLink_Click(object sender, CommandEventArgs e)
        {
            Session["CountCart"] = (int)Session["CountCart"] - 1;
            LinkButton btn = (LinkButton)sender;
            int id = int.Parse(btn.CommandArgument);
            if (Session["username"] == null)
            {
                string CartId = Session["ShoppingCartID"].ToString();
                int count = (int)DAO.GetData(new SqlCommand("SELECT COUNT FROM Carts WHERE CartId='" + CartId + "' and AlbumId=" + id));
                if (count > 1)
                {
                    CartDAO.Update(CartId, id);
                }
                else
                {
                    CartDAO.Delete(CartId, id);
                }
            }
            else
            {
                string CartId = Session["username"].ToString();
                int count = (int)DAO.GetData(new SqlCommand("SELECT COUNT FROM Carts WHERE CartId='" + CartId + "' and AlbumId=" + id));
                if (count > 1)
                {
                    CartDAO.Update(CartId, id);
                }
                else
                {
                    CartDAO.Delete(CartId, id);
                }
            }
            Response.Redirect("/GUI/CartGUI.aspx");
        }
    }
}