<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetailGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
        <br />
        <asp:Image ID="image" runat="server" />
    </p>
    <p>
        &nbsp;<table style="width:100%;">
            <tr>
                <td class="auto-style1">Artist:</td>
                <td>
                    
                    <asp:TextBox ID="tbArtist" runat="server" Width="282px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Genre:</td>
                <td>
                <asp:TextBox ID="tbGenre" runat="server" Width="286px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Price:</td>
                <td>
                    <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" BackColor="Black" Font-Bold="True" ForeColor="White" />
        <asp:Button runat="server" Text="Back"  ID="btnBack" BackColor="Black" Font-Bold="True" ForeColor="White" OnClick="btnBack_Click" Width="102px" />
    </p>
</asp:Content>
