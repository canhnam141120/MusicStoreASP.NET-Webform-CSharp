using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    public class OrderDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "Select * from Orders";
            return DAO.GetDataTable(sql);

        }

        static public int GetMaxID()
        {
            int max = -1;
            string sql = "Select Max(OrderID) as MaxID from Orders";
            DataTable dt = DAO.GetDataTable(sql);
            if (dt.Rows.Count > 0) max = (int)dt.Rows[0]["MaxID"];
            return max;
        }

        public static bool Insert(Order a)
        {
            SqlCommand cmd = new SqlCommand("Insert into Orders(OrderDate,PromoCode,UserName,FirstName,LastName,Address,City,State,Country,Phone,Email,Total) " +
                "Values(@OrderDate,@PromoCode,@UserName,@FirstName,@LastName,@Address,@City,@State,@Country,@Phone,@Email,@Total)");
            cmd.Parameters.AddWithValue("@OrderDate", a.OrderDate);
            cmd.Parameters.AddWithValue("@PromoCode", a.PromoCode);
            cmd.Parameters.AddWithValue("@UserName", a.UserName);
            cmd.Parameters.AddWithValue("@FirstName", a.FirstName);
            cmd.Parameters.AddWithValue("@LastName", a.Lastname);
            cmd.Parameters.AddWithValue("@Address", a.Address);
            cmd.Parameters.AddWithValue("@City", a.City);
            cmd.Parameters.AddWithValue("@State", a.State);
            cmd.Parameters.AddWithValue("@Country", a.Country);
            cmd.Parameters.AddWithValue("@Phone", a.Phone);
            cmd.Parameters.AddWithValue("@Email", a.Email);
            cmd.Parameters.AddWithValue("@Total", a.Total);

            return DAO.UpdateTable(cmd);
        }

        public static bool Update(Order a)
        {
            SqlCommand cmd = new SqlCommand("Update Orders set OrderDate=@OrderDate, FirstName=@FirstName, LastName=@LastName, " +
                "Address=@Address, City=@City, State=@State, Country=@Country, Phone=@Phone, Email=@Email WHERE OrderID=@OrderID");
            cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
            cmd.Parameters.AddWithValue("@OrderDate", a.OrderDate);
            cmd.Parameters.AddWithValue("@FirstName", a.FirstName);
            cmd.Parameters.AddWithValue("@LastName", a.Lastname);
            cmd.Parameters.AddWithValue("@Address", a.Address);
            cmd.Parameters.AddWithValue("@City", a.City);
            cmd.Parameters.AddWithValue("@State", a.State);
            cmd.Parameters.AddWithValue("@Country", a.Country);
            cmd.Parameters.AddWithValue("@Phone", a.Phone);
            cmd.Parameters.AddWithValue("@Email", a.Email);
            return DAO.UpdateTable(cmd);
        }

        public static bool Delete(Order a)
        {
            SqlCommand cmd = new SqlCommand("Delete from Orders where OrderID=@OrderID");
            cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
            return DAO.UpdateTable(cmd);
        }
    }
}