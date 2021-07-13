using SE1432_Group2_Lab4.DTL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1432_Group2_Lab4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlArtist.DataSource = AlbumDAO.getArtist();
                ddlArtist.DataValueField = "ArtistID";
                ddlArtist.DataTextField = "Name";
                ddlArtist.DataBind();
                ddlGenre.DataSource = AlbumDAO.getGenre();
                ddlGenre.DataValueField = "GenreID";
                ddlGenre.DataTextField = "Name";
                ddlGenre.DataBind();
                if (Request.QueryString["add"] != null)
                {
                    int add = int.Parse(Request.QueryString["add"]);
                    if (add == 1)
                        Label1.Text = "Add a new Album";
                    else
                        Label1.Text = "Edit An Album";
                }
                if (Session["AlbumID"] != null)
                {
                    int albumID = int.Parse(Session["AlbumID"].ToString());
                    Album album = AlbumDAO.SearchAlbumByID(albumID);
                    TxtTitle.Text = album.Title;
                    txtPrice.Text = album.Price.ToString();
                    txtURL.Text = album.AlbumUrl;
                    ddlArtist.SelectedValue = album.ArtistID.ToString();
                    ddlGenre.SelectedValue = album.GenreID.ToString();
                    Image2.ImageUrl = txtURL.Text;
                }
            }
            else
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["add"] == null)
            {
                Response.Write("<script>alert('Error')</script>");
                Response.Redirect("AlbumGUI.aspx");
            }
            else
            {
                int add = int.Parse(Request.QueryString["add"]);
                if (add == 1)
                {
                    bool isSuccess = AlbumDAO.Insert(new Album(0, int.Parse(ddlGenre.SelectedValue.ToString()), int.Parse(ddlArtist.SelectedValue.ToString()), TxtTitle.Text, double.Parse(txtPrice.Text), txtURL.Text));
                    if (isSuccess)
                    {
                        Response.Write("<script>alert('Insert success')</script>");
                        Response.Redirect("AlbumGUI.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Insert fail')</script>");
                    }
                }
                else
                {
                    int albumID = int.Parse(Session["AlbumID"].ToString());
                    bool isSuccess = AlbumDAO.Update(new Album(albumID, int.Parse(ddlGenre.SelectedValue.ToString()), int.Parse(ddlArtist.SelectedValue.ToString()), TxtTitle.Text, double.Parse(txtPrice.Text), txtURL.Text));
                    if (isSuccess)
                    {
                        Session.Remove("AlbumID");
                        Response.Write("<script>alert('Update success')</script>");
                        Response.Redirect("AlbumGUI.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Update fail')</script>");
                    }
                }
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string savePath = Server.MapPath("/Images") + "/";
            if (FileUpload1.HasFile)
            {

                long elapsedTicks = DateTime.Now.Ticks - new DateTime(2001, 1, 1).Ticks;
                String fileName = FileUpload1.FileName.Substring(0, FileUpload1.FileName.LastIndexOf('.')) + elapsedTicks + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                savePath += fileName;
                FileUpload1.SaveAs(savePath);
                txtURL.Text = "/Images/" + fileName;
                Image2.ImageUrl = "/Images/" + fileName;
            }
            else
            {
                LblError.Text = "You did not specify a file to upload.";
                Response.Write("<script>alert('Error')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("AlbumID");
            Response.Redirect("AlbumGUI.aspx");
        }
    }
}