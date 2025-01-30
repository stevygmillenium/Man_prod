<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_prod.aspx.cs" Inherits="Man_prod.View_prod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Style_sheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            product_name:
            <asp:Label ID="product_nameLabel" runat="server" Text='<%# Eval("product_name") %>' />
            <br />
            price:
            <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
            <br />
            quantity:
            <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
            <br />
            image:
            <asp:Label ID="imageLabel" runat="server" Text='<%# Eval("image") %>' />
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#"Get_image.ashx?id="+Eval("id") %>' Height="77.5px" Width="170.5px" />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>
    <div class="view">
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="product_name" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
    </div>    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="del_row">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="name" HeaderText="product name" />
            <asp:BoundField DataField="price" HeaderText="price" />
            <asp:TemplateField HeaderText="image">
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("image") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval( "image") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="amount">
                <ItemTemplate>
                    <asp:TextBox ID="amt" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="sub total">
                <ItemTemplate>
                    <asp:Label ID="sub_t" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Delete" HeaderText="remove" ShowHeader="True" Text="Button" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <div id="check_out">
        <asp:TextBox ID="TextBox2" runat="server" ToolTip="name"></asp:TextBox><br />
        <asp:TextBox ID="TextBox3" runat="server" ToolTip="email"></asp:TextBox><br />
        <asp:TextBox ID="TextBox4" runat="server" ToolTip="address"></asp:TextBox><br />
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    </div>    
</asp:Content>
