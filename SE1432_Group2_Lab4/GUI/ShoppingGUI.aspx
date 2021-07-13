<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 264px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblList" runat="server" Text="List of Genres:"></asp:Label>
    <br />
    <table style="width: 98%;">
        <tr>
            <td class="auto-style1">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" Width="149px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="GenreId" EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataTable" TypeName="SE1432_Group2_Lab4.DAL.GenreDAO"></asp:ObjectDataSource>
            </td>
            <td>
                <asp:Image ID="Image2" runat="server" Height="297px" ImageUrl="~/Images/home-showcase.png" Width="649px" />
            </td>
        </tr>
    </table>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15pt" Text="Label"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource2" Width="785px" EnableModelValidation="True">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="btnDetail" runat="server" NavigateUrl = '<%# "/GUI/AlbumDetailGUI.aspx?ID=" + Eval("AlbumID") %>' >Detail</asp:HyperLink>
                </ItemTemplate>
                <ControlStyle ForeColor="#0000CC" />
                <ItemStyle ForeColor="#0E41A4" />
            </asp:TemplateField>
            <asp:BoundField DataField="AlbumId" HeaderText="AlbumId" />
            <asp:BoundField DataField="GenreId" HeaderText="GenreId" Visible="False" />
            <asp:BoundField DataField="ArtistId" HeaderText="ArtistId" Visible="False" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="AlbumUrl" HeaderText="AlbumUrl" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        
</asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAlbumsByGenre" TypeName="SE1432_Group2_Lab4.DTL.AlbumDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DefaultValue="1" Name="genreId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>
