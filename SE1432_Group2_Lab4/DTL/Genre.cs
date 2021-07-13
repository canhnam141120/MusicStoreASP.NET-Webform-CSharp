using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class Genre
    {
        private int genreId;

        public int GenreId
        {
            get { return genreId; }
            set { genreId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}