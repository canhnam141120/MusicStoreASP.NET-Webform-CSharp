using SE1432_Group2_Lab4.DAL;
using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string s = Session["username"].ToString();
                UserInfo uI = UserDAO.Instance.getInfo(s);
                txtUserName.Text = s;
                txtFirstName.Text = uI.FirstName;
                txtLastName.Text = uI.LastName;
                txtAddress.Text = uI.Address;
                txtCity.Text = uI.City;
                txtState.Text = uI.State;
                txtPhone.Text = uI.Phone;
                txtEmail.Text = uI.Email;
                txtCountry.Text = uI.Country;
                txtTotal.Text = Session["totalCart"].ToString();
                txtOrderDate.Text = DateTime.Now.ToString("dd,MM,yyyy");
            }
            else
            {
                Response.Redirect("/GUI/LoginGUI.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartGUI.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.OrderID = OrderDAO.GetMaxID() + 1;
            order.OrderDate = DateTime.Today;
            order.UserName = txtUserName.Text;
            order.FirstName = txtFirstName.Text;
            order.Lastname = txtLastName.Text;
            order.Address = txtAddress.Text;
            order.City = txtCity.Text;
            order.State = txtState.Text;
            order.Country = txtCountry.Text;
            order.Email = txtEmail.Text;
            order.Phone = txtPhone.Text;
            order.Total = double.Parse(txtTotal.Text);
            order.PromoCode = txtPromocode.Text;
            OrderDAO.Insert(order);
            List<OrderDetail> ods = (List<OrderDetail>)Session["Cart"];
            foreach (OrderDetail ot in ods)
            {
                ot.OrderID = order.OrderID;
                OrderDetailDAO.Insert(ot);
            }
            Session["CountCart"] = null;
            CartDAO.Delete(Session["username"].ToString());
            Response.Redirect("CompleteOrderGUI.aspx?orderid=" + order.OrderID);
        }
    }
}