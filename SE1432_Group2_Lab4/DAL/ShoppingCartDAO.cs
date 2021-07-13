using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE1432_Group2_Lab4.DAL
{
    public class ShoppingCartDAO
    {
        public static string ShoppingCartId { get; set; }
        static string cartID { get; set; }
        public static string UserName { get; set; }
        public static string GetCart()
        {
            Guid tempCartId = Guid.NewGuid();
            cartID = tempCartId.ToString();
            return cartID;
        }

        public List<Cart> GetCartItems()
        {
            List<Cart> cartItems = CartDAO.GetCarts()
                    .Where(c => c.CartID == ShoppingCartId).ToList<Cart>();
            return cartItems;
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            List<Cart> cartItems = GetCartItems();
            int count = 0;
            if (cartItems != null)
                foreach (Cart cartItem in cartItems)
                    count += cartItem.Count;
            return count;
        }
        public double GetTotal()
        {
            // Multiply album price by count of that album to get
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            double total = 0;
            List<Cart> cartItems = GetCartItems();
            if (cartItems != null)
                foreach (Cart cart in cartItems)
                    total += cart.Count * AlbumDAO.SearchAlbumByID(cart.AlbumID).Price;
            return total;
        }
        public int CreateOrder(Order order)
        {
            // Save the order
            OrderDAO.Insert(order);
            int orderID = OrderDAO.GetMaxID();
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, adding the 
            // order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    AlbumID = item.AlbumID,
                    OrderID = orderID,
                    UnitPrice = AlbumDAO.SearchAlbumByID(item.AlbumID).Price,
                    Quantity = item.Count
                };
                OrderDetailDAO.Insert(orderDetail);
            }

            // Empty the shopping cart
            CartDAO.Delete(ShoppingCartId);
            // Return the OrderId as the confirmation number
            return orderID;
        }
        public void AddToCart(int id)
        {
            // Get the matching cart and album instances
            var cartItem = CartDAO.GetCarts().Where(c => c.CartID == ShoppingCartId
                && c.AlbumID == id).FirstOrDefault();
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    AlbumID = id,
                    CartID = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                CartDAO.Insert(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
                CartDAO.Update(cartItem);
            }
        }

        public void RemoveFromCart(int id)
        {
            // Get the cart
            // Get the matching cart and album instances
            var cartItem = GetCartItems().Where(c => c.AlbumID == id).First();
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                    CartDAO.Update(cartItem);
                }
                else
                {
                    CartDAO.Delete(ShoppingCartId, id);
                }
            }
        }

        public void EmptyCart() => CartDAO.Delete(ShoppingCartId);

        public string GetCartId()
        {
            if (cartID == null)
            {
                if (UserName != null)
                    cartID = UserName;
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    cartID = tempCartId.ToString();
                }
            }
            return cartID;
        }

        // When a user has logged in, migrate their shopping cart 
        // to be associated with their username
        public void MigrateCart()
        {
            CartDAO.MigrateCart(ShoppingCartId, UserName);
            cartID = UserName;
        }

        public void ResetCartID()
        {
            cartID = null;
        }
    }
}