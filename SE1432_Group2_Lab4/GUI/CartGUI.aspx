<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnCheckout" runat="server" Text="Check out &gt;" OnClick="btnCheckout_Click" BackColor="Black" ForeColor="White" Height="32px" Width="161px" EnableTheming="True" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Total:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbTotal" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>
    <br />
    <asp:ListView ID="ListView1" runat="server" >
           <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:HyperLink ID="Detail" runat="server" Text='Detail' NavigateUrl = '<%# Eval("AlbumID", "/GUI/AlbumDetailGUI.aspx?add=1&ID={0}") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="AlbumIDLabel" runat="server" Text='<%# Eval("AlbumId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountLabel" runat="server" Text='<%# Eval("Count") %>' />
                    </td>
                     <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="RemoveLink" runat="server" Text="Remove from cart" OnCommand="RemoveLink_Click" CommandArgument='<%# Eval("AlbumID", "{0}") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" style="">
                                <tr runat="server" style="">
                                    <th id="Th1" runat="server">
                                        Detail</th>
                                    <th id="Th2" runat="server">
                                        AlbumID</th>
                                    <th id="Th3" runat="server">
                                        Count</th>
                                    <th id="Th4" runat="server">
                                        Date</th>
                                    <th id="Th5" runat="server">
                                        Remove</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr> 
                            </table>
                        </td>
                    </tr>
                </table>
             </LayoutTemplate>
        </asp:ListView>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15pt" Text="Your Cart is Empty!" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>

