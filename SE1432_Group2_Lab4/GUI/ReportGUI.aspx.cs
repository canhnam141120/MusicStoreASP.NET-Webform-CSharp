using SE1432_Group2_Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvOrder.DataSource = OrderDAO.GetDataTable();
                dgvOrder.DataBind();

            }
        }

        private void getOrderData()
        {
            try
            {
                string sql = "SELECT OrderId, CONVERT(varchar, OrderDate, 103) OrderDate, PromoCode, UserName, FirstName, LastName, " +
                "Address, City, State, Country, Phone, Email, Total from Orders WHERE 1=1 ";

                if (!txtFrom.Text.Trim().Equals("")) sql += "AND orderDate BETWEEN @start AND @end ";
                sql += "AND firstName LIKE @firstName AND Country LIKE @country";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@firstName", "%" + txtFirstName.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@country", "%" + txtCountry.Text.Trim() + "%");
                if (!txtFrom.Text.Trim().Equals(""))
                {
                    cmd.Parameters.AddWithValue("@start", DateTime.ParseExact(txtFrom.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    cmd.Parameters.AddWithValue("@end", DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                }

                DataTable dt = DAO.GetDataTable(cmd);
                dgvOrder.DataSource = dt;
                dgvOrder.DataBind();
                lblOrder.Text = "The numbers of orders: " + dgvOrder.Rows.Count.ToString();
            }
            catch (Exception)
            {

            }
        }

        protected void mcDatePicker_SelectionChanged(object sender, EventArgs e)
        {

            DateTime start = mcDatePicker.SelectedDates[0];
            DateTime end = mcDatePicker.SelectedDates[mcDatePicker.SelectedDates.Count - 1];
            txtFrom.Text = start.ToString("dd/MM/yyyy");
            txtTo.Text = end.ToString("dd/MM/yyyy");
        }

        protected void dgvOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrder.PageIndex = e.NewPageIndex;
            dgvOrder.DataSource = OrderDAO.GetDataTable();
            dgvOrder.DataBind();
            //getOrderData();
        }

        protected void dgvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRow == null) return;

            int OID = int.Parse(dgvOrder.SelectedRow.Cells[1].Text);
            mcDatePicker.TodaysDate = DateTime.ParseExact(dgvOrder.SelectedRow.Cells[2].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime start = DateTime.ParseExact(dgvOrder.SelectedRow.Cells[2].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtFrom.Text = start.ToString("dd/MM/yyyy");
            txtTo.Text = start.ToString("dd/MM/yyyy");
            string fn = dgvOrder.SelectedRow.Cells[5].Text;
            string country = dgvOrder.SelectedRow.Cells[10].Text;
            txtFirstName.Text = fn;
            txtCountry.Text = country;

            SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetails WHERE OrderId = @oid");
            cmd.Parameters.AddWithValue("@oid", OID);
            DataTable dt = DAO.GetDataTable(cmd);
            dgvOrderDetail.DataSource = dt;
            dgvOrderDetail.DataBind();
            mcDatePicker.SelectedDate = DateTime.ParseExact(dgvOrder.SelectedRow.Cells[2].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        protected void dgvOrderDetail_DataBound(object sender, EventArgs e)
        {
            lblDetail.Text = "Number of Order Detail: " + dgvOrderDetail.Rows.Count;
        }

        protected void dgvOrder_DataBound(object sender, EventArgs e)
        {
            lblOrder.Text = "The numbers of orders: " + dgvOrder.Rows.Count;
            foreach (GridViewRow r in dgvOrder.Rows)
            {
                r.Cells[2].Text = DateTime.Parse(r.Cells[2].Text).ToString("dd/MM/yyyy");
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRow != null)
            {
                dgvOrder.SelectedIndex = -1;
            }
            dgvOrderDetail.DataSource = null;
            dgvOrderDetail.DataBind();
            lblDetail.Text = "";
            getOrderData();
        }
    }
}