using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class Album
    {
        private int albumID;

        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }

        private int genreID;

        public int GenreID
        {
            get { return genreID; }
            set { genreID = value; }
        }
        private int artistID;

        public int ArtistID
        {
            get { return artistID; }
            set { artistID = value; }
        }

        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string albumUrl;

        public string AlbumUrl
        {
            get { return albumUrl; }
            set { albumUrl = value; }
        }

        public Album(int albumID, int genreID, int artistID, string title, double price, string albumUrl)
        {
            AlbumID = albumID;
            GenreID = genreID;
            ArtistID = artistID;
            Title = title;
            Price = price;
            AlbumUrl = albumUrl;
        }

        public Album() { }
    }
}