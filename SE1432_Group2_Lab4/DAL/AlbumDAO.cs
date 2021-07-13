using SE1432_Group2_Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class AlbumDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "select * from Albums";
            return DAO.GetDataTable(sql);
        }

        public static DataTable getArtist()
        {
            return DAO.GetDataTable("select * from Artists");
        }

        public static DataTable getGenre()
        {
            return DAO.GetDataTable("select * from Genres");
        }

        public static Album SearchAlbumByID(int AlbumID)
        {
            DataTable dt = DAO.GetDataTable("SELECT * FROM Albums WHERE AlbumId = " + AlbumID);
            Album album = new Album();
            DataRow row = dt.Rows[0];
            album.AlbumID = (int)(row["AlbumID"]);
            album.ArtistID = (int)row["ArtistID"];
            album.GenreID = (int)row["GenreID"];
            album.Title = row["Title"].ToString();
            album.Price = double.Parse(row["Price"].ToString());
            album.AlbumUrl = row["AlbumURL"].ToString();
            return album;
        }

        public static Artist SearchArtistByID(int ArtistId)
        {
            DataTable dt = DAO.GetDataTable("SELECT * FROM Artists WHERE ArtistId = " + ArtistId);
            Artist artist = new Artist();
            DataRow row = dt.Rows[0];
            artist.ArtistId = (int)(row["ArtistId"]);
            artist.Name = row["Name"].ToString();
            return artist;
        }

        public static Genre SearchGenreByID(int GenreId)
        {
            DataTable dt = DAO.GetDataTable("SELECT * FROM Genres WHERE GenreId = " + GenreId);
            Genre genre = new Genre();
            DataRow row = dt.Rows[0];
            genre.GenreId = (int)(row["GenreId"]);
            genre.Name = row["Name"].ToString();
            genre.Description = row["Description"].ToString();
            return genre;
        }
        public static bool Insert(Album a)
        {
            SqlCommand cmd = new SqlCommand("Insert into Albums(GenreID, ArtistID, Title, Price, AlbumURL) " +
                "Values(@GenreID, @ArtistID, @Title, @Price, @AlbumURL)");
            cmd.Parameters.AddWithValue("@GenreID", a.GenreID);
            cmd.Parameters.AddWithValue("ArtistID", a.ArtistID);
            cmd.Parameters.AddWithValue("@Title", a.Title);
            cmd.Parameters.AddWithValue("@Price", a.Price);
            cmd.Parameters.AddWithValue("@AlbumURL", a.AlbumUrl);
            return DAO.UpdateTable(cmd);

        }

        public static bool Update(Album a)
        {
            SqlCommand cmd = new SqlCommand("Update Albums set GenreID=@GenreID, " +
                "ArtistID=@ArtistID,Title=@Title,Price=@Price, AlbumURL=@AlbumURL " +
                "WHERE AlbumID=@AlbumID");
            cmd.Parameters.AddWithValue("@AlbumID", a.AlbumID);
            cmd.Parameters.AddWithValue("@GenreID", a.GenreID);
            cmd.Parameters.AddWithValue("@ArtistID", a.ArtistID);
            cmd.Parameters.AddWithValue("@Title", a.Title);
            cmd.Parameters.AddWithValue("@Price", a.Price);
            cmd.Parameters.AddWithValue("@AlbumURL", a.AlbumUrl);

            return DAO.UpdateTable(cmd);

        }

        public static bool Delete(Album a)
        {
            SqlCommand cmd = new SqlCommand("Delete from Albums where AlbumID=@AlbumID");
            cmd.Parameters.AddWithValue("@AlbumID", a.AlbumID);
            return DAO.UpdateTable(cmd);
        }

        public static DataTable GetAlbumsByGenre(int genreId)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM dbo.Albums WHERE GenreId = @id");
            cmd.Parameters.AddWithValue("@id", genreId);
            return DAO.GetDataTable(cmd);
        }
    }
}