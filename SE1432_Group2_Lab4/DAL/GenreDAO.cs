using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    public class GenreDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "SELECT * FROM Genres";
            return DAO.GetDataTable(sql);
        }
    }
}