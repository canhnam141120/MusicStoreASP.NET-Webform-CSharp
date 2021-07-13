using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DTL
{
    public class OrderDetail
    {
        private int orderDetailID;

        public int OrderDetailID
        {
            get { return orderDetailID; }
            set { orderDetailID = value; }
        }
        private int orderID;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        private int albumID;

        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }
}