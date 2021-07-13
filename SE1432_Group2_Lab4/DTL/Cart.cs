using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class Cart
    {
        private int recordId;
        public int RecordID
        {
            get { return recordId; }
            set { recordId = value; }
        }
        private string cartID;

        public string CartID
        {
            get { return cartID; }
            set { cartID = value; }
        }

        private int albumId;
        public int AlbumID
        {
            get { return albumId; }
            set { albumId = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
    }
}