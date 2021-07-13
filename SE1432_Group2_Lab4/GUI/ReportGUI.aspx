<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportGUI.aspx.cs" Inherits="SE1432_Group2_Lab4.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.auto-style1 {
			width: 251px;
		}
		.auto-style2 {
			width: 337px;
		}
		</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<p>
		Order date:</p>
	<p>
		<table style="width:100%;">
			<tr>
				<td class="auto-style1">
					<asp:Calendar ID="mcDatePicker" runat="server" OnSelectionChanged="mcDatePicker_SelectionChanged" SelectionMode="DayWeekMonth" Font-Italic="False" Font-Overline="False" Font-Underline="True"></asp:Calendar>
				</td>
				<td class="auto-style2">
					<asp:Label ID="Label1" runat="server" Text="From"></asp:Label><br />
					<asp:TextBox ID="txtFrom" runat="server" Enabled="False" ReadOnly="True" Width="235px"></asp:TextBox><br />
					<asp:Label ID="Label2" runat="server" Text="To"></asp:Label><br />
					<asp:TextBox ID="txtTo" runat="server" Enabled="False" ReadOnly="True" Width="235px"></asp:TextBox><br />
					<asp:Label ID="Label3" runat="server" Text="FirstName"></asp:Label><br />
					<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
					<asp:Label ID="Label4" runat="server" Text="Country"></asp:Label><br />
					<asp:TextBox ID="txtCountry" runat="server"></asp:TextBox><br />


				</td>
				<td>
					<br /><br /><br /><br />
					<br /><br /><br />
					<br />
					<asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" Width="108px" />
				</td>
			</tr>
		</table>
	</p>
	<p>
		<asp:Label ID="lblOrder" runat="server" Text="The number of orders: "></asp:Label>
	</p>
	<p>
		<asp:GridView ID="dgvOrder" runat="server" AllowPaging="True" DataKeyNames="OrderID" OnSelectedIndexChanged="dgvOrder_SelectedIndexChanged" OnDataBound="dgvOrder_DataBound" OnPageIndexChanging="dgvOrder_PageIndexChanging" PageSize="5" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
			</Columns>
			<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
			<SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
		    
		</asp:GridView>
	</p>
	<p>
		<asp:Label ID="lblDetail" runat="server"></asp:Label>
	</p>
	<p>
		<asp:GridView ID="dgvOrderDetail" runat="server" OnDataBound="dgvOrderDetail_DataBound" PageSize="5" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            
		</asp:GridView>
	</p>
</asp:Content>
