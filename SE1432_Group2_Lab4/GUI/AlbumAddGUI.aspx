<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumAddGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
        .auto-style2 {
            width: 779px;
        }
        .auto-style3 {
            height: 31px;
            width: 779px;
        }
        .auto-style4 {
            width: 82%;
        }
        .auto-style5 {
            height: 21px;
            width: 779px;
        }
        .auto-style6 {
            height: 21px;
        }
        .auto-style7 {
            height: 32px;
            width: 779px;
        }
        .auto-style8 {
            height: 32px;
        }
        .auto-style9 {
            width: 779px;
            height: 25px;
        }
        .auto-style10 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Add a new Album"></asp:Label>
        <asp:Label ID="LblError" runat="server" ForeColor="#FF3300"></asp:Label>
        <table class="auto-style4">
            <tr>
                <td class="auto-style5">Title<asp:TextBox ID="TxtTitle" runat="server" Style="margin-left: 19px" Width="252px" Height="21px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTitle" ErrorMessage="Title required" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">Genre<asp:DropDownList ID="ddlGenre" runat="server" Height="32px" Style="margin-left: 7px" Width="256px">
                </asp:DropDownList>
                </td>
                <td rowspan="2">
                    <asp:Image ID="Image2" runat="server" ImageAlign="Middle" />
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style3">Artist<asp:DropDownList ID="ddlArtist" runat="server" Height="31px" Style="margin-left: 13px" Width="252px">
                </asp:DropDownList>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1">&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">Price<asp:TextBox ID="txtPrice" runat="server" Style="margin-left: 17px" Width="252px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrice" ErrorMessage=" Price required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="From 0 to 9999" ForeColor="Red" MaximumValue="9999" MinimumValue="0"></asp:RangeValidator>
                    </td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    URL<asp:TextBox ID="txtURL" runat="server" Style="margin-left: 23px" Width="252px" ReadOnly="True"></asp:TextBox>

                    <asp:Button ID="BtnUpload" runat="server" Text="Save Image File" OnClick="BtnUpload_Click" />
                    <asp:FileUpload ID="FileUpload1" runat="server"/>
                </td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="69px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="margin-left: 16px" Width="65px" OnClick="btnCancel_Click" CausesValidation="False" />
                </td>
            </tr>
        </table>
        <br />
        &nbsp;
    </p>
</asp:Content>

