using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    class DAO
    {
        static string strConn = ConfigurationManager.ConnectionStrings["MusicStoreConnectionString"].ConnectionString;
        static public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        static public DataTable GetDataTable(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        static public bool UpdateTable(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {

                return false;

            }
        }

        static public object GetData(SqlCommand cmd)
        {
            try
            {
                object a;
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                conn.Open();
                a = cmd.ExecuteScalar();
                conn.Close();
                return a;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        static public int GetRole(SqlCommand cmd)
        {
            try
            {
                int a;
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                conn.Open();
                a = (int)cmd.ExecuteScalar();
                conn.Close();
                return a;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

    }
}