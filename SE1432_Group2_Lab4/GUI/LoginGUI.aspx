<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Login" Font-Bold="True" Font-Size="X-Large"></asp:Label><br />
    <table style="width:100%;">
            <tr>
                <td class="auto-style1">Username:</td>
                <td>
                    
                    <asp:TextBox ID="tbUsername" runat="server" Width="282px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Password:</td>
                <td>
                <asp:TextBox ID="tbPassworld" runat="server" Width="282px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
    <asp:Button ID="Button1" runat="server" Text="Login" Font-Bold="True" Width="173px" OnClick="Button1_Click" />
    <asp:Label ID="lbThongbao" runat="server" ForeColor="Red"></asp:Label>

</asp:Content>
