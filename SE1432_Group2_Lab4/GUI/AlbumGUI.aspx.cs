using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumAddGUI.aspx?add=1");
        }

        protected void BtEddit_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                LblError.Text = "You must select an Album ";
                return;
            }
            Session["AlbumID"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("AlbumAddGUI.aspx?add=0");
        }
    }
}