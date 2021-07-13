using SE1432_Group2_Lab4.DAL;
using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["ID"]);
                string sql = @"SELECT ab.Title, ar.Name [Artist], g.Name [Genre], ab.Price, ab.AlbumUrl " +
                             "FROM dbo.Albums ab INNER JOIN dbo.Artists ar ON ar.ArtistId = ab.ArtistId INNER JOIN dbo.Genres g ON g.GenreId = ab.GenreId " +
                             "WHERE ab.AlbumId = @Id";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@Id", id);
                DataTable dt = DAO.GetDataTable(cmd);
                DataRow row = dt.Rows[0];
                lblTitle.Text = row["Title"].ToString();
                tbArtist.Text = row["Artist"].ToString();
                tbGenre.Text = row["Genre"].ToString();
                tbPrice.Text = row["Price"].ToString();
                image.ImageUrl = row["AlbumUrl"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("ShoppingGUI.aspx");
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            ShoppingCartDAO scd = new ShoppingCartDAO();
            DateTime now = DateTime.Now;
            Cart c = new Cart();
            ShoppingCartDAO.ShoppingCartId = scd.GetCartId();
            c.AlbumID = int.Parse(Request.QueryString["ID"]);
            if (Session["username"] != null)
            {
                c.CartID = Session["username"].ToString();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Carts WHERE CartId = '" + c.CartID + "' and AlbumId =" + c.AlbumID);
                DataTable data1 = DAO.GetDataTable(cmd2);

                if (data1.Rows.Count == 0)
                {
                    c.Count = 1;
                    c.DateCreated = now;
                    CartDAO.Insert(c);
                }
                else
                {
                    CartDAO.Update(c);
                }
            }
            if (Session["username"] == null)
            {
                c.CartID = ShoppingCartDAO.ShoppingCartId;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Carts WHERE CartId = '" + c.CartID + "' and AlbumId =" + c.AlbumID);
                DataTable data = DAO.GetDataTable(cmd);

                if (data.Rows.Count == 0)
                {
                    c.Count = 1;
                    c.DateCreated = now;
                    CartDAO.Insert(c);
                }
                else
                {
                    CartDAO.Update(c);
                }
            }
            Session["ShoppingCartID"] = ShoppingCartDAO.ShoppingCartId;
            Response.Redirect("/GUI/CartGUI.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingGUI.aspx");
        }
    }
}