using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class Artist
    {
        private int artistId;

        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}