
using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    public class CartDAO
    {
        public static IEnumerable<Cart> GetCarts()
        {
            var carts = new List<Cart>();
            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var c = new Cart
                    {
                        RecordID = (int)row["recordID"],
                        CartID = row["CartID"].ToString(),
                        AlbumID = (int)row["AlbumID"],
                        Count = (int)row["Count"],
                        DateCreated = (DateTime)row["DateCreated"]
                    };
                    carts.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carts.AsEnumerable();
        }
        public static DataTable GetDataTable()
        {
            return DAO.GetDataTable("SELECT * FROM carts");
        }

        public static void Insert(Cart cart)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Carts VALUES(" +
                    "@CartID, @albumID, @count, @dateCreated)");
                cmd.Parameters.AddWithValue("@cartID", cart.CartID);
                cmd.Parameters.AddWithValue("@albumID", cart.AlbumID);
                cmd.Parameters.AddWithValue("@count", cart.Count);
                cmd.Parameters.AddWithValue("@dateCreated", cart.DateCreated);
                DAO.UpdateTable(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(string cartID, int albumID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Carts SET [Count] = [Count] -1   Where CartId = '" + cartID + "' and AlbumId =" + albumID);
                DAO.UpdateTable(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public static void Update(Cart cart)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Carts SET [Count] = [Count] + 1   Where CartId = '" + cart.CartID + "' and AlbumId =" + cart.AlbumID);
                DAO.UpdateTable(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void Delete(string cartID, int albumID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Carts WHERE cartID = @cartID "
                    + "AND albumID = @albumID");
                cmd.Parameters.AddWithValue("cartID", cartID);
                cmd.Parameters.AddWithValue("albumID", albumID);
                DAO.UpdateTable(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public static void Delete(string cartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Carts WHERE cartID = @cartID");
                cmd.Parameters.AddWithValue("cartID", cartID);

                DAO.UpdateTable(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static void MigrateCart(string shoppingCartId, string userName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE carts SET cartID = @userName "
                    + "WHERE cartID = @shoppingCartID");
                cmd.Parameters.AddWithValue("@shoppingCartID", shoppingCartId);
                cmd.Parameters.AddWithValue("@userName", userName);
                DAO.UpdateTable(cmd);
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message);
            }
        }
    }
}