using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return instance; }
            private set { instance = value; }
        }
        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM dbo.[Users] WHERE UserName = N'" + username + "' AND Password =N'" + password + "'";
            DataTable result = DAO.GetDataTable(query);
            return result.Rows.Count > 0;
        }

        public UserInfo getInfo(string Username)
        {
            UserInfo userInfo = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName = @Username");
                cmd.Parameters.AddWithValue("@Username", Username);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    userInfo = new UserInfo
                    {
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Address = row["Address"].ToString(),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        Country = row["Country"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),

                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userInfo;
        }

    }
}