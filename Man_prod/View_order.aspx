<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_order.aspx.cs" Inherits="Man_prod.View_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Style_sheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="show_order">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="name" HeaderText="customer name" />
            <asp:BoundField DataField="email" HeaderText="email" />
            <asp:BoundField DataField="address" HeaderText="address" />
            <asp:BoundField DataField="card_type" HeaderText="card type" />
            <asp:BoundField DataField="dateTime" HeaderText="date and time" />
            <asp:BoundField DataField="amount" HeaderText="amount" />
            <asp:ButtonField ButtonType="Button" Text="Button" />
        </Columns>
    </asp:GridView>
    <asp:Table ID="Table1"  runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Xml ID="Xml1" runat="server" TransformSource="order_data.xslt"></asp:Xml>    
</asp:Content>
