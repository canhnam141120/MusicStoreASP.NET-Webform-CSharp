<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm6" %>
<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 259px;
    }
    .auto-style2 {
        width: 329px;
    }
    .auto-style4 {
        width: 259px;
        height: 26px;
    }
    .auto-style5 {
        width: 329px;
        height: 26px;
    }
    .auto-style6 {
        height: 26px;
    }
        .auto-style7 {
            width: 259px;
            height: 29px;
        }
        .auto-style8 {
            width: 329px;
            height: 29px;
        }
        .auto-style9 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Shipping information:"></asp:Label>
&nbsp;&nbsp;
<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
<br />
<table style="width:100%;">
    <tr>
        <td class="auto-style1">Order date:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtOrderDate" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">UserName:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtUserName" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td class="auto-style6">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">First name:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtFirstName" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Last name:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtLastName" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Address:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtAddress" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">City:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtCity" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">State:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtState" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Country:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtCountry" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">Phone:</td>
        <td class="auto-style8">
            <asp:TextBox ID="txtPhone" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style1">Email:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required!" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is not valid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Total:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">PromoCode:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtPromocode" runat="server" Width="100%">FREE</asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="btnSubmit" runat="server" Text="Order" Width="175px" OnClick="btnSubmit_Click" />
        </td>
        <td class="auto-style2">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="175px" CausesValidation="False" OnClick="btnCancel_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
