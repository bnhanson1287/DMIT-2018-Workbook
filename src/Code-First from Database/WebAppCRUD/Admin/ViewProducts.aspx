<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="WebAppCRUD.Admin.ViewProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Products</h1>
    <asp:GridView ID="ProductGridView" runat="server" CssClass="table table-cover" AutoGenerateColumns="False" DataSourceID="ProductsDataSource" ItemType="WestWindSystem.Entities.Product">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName"></asp:BoundField>
            <asp:TemplateField HeaderText="Supplier">
                <ItemTemplate>
                    <asp:DropDownList ID="SupplierDropDown" runat="server" DataSourceID="SupplierDataSource" SelectedValue="<%# Item.SupplierID %>" DataTextField="CompanyName" DataValueField="SupplierID"
                        enabled="false"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:DropDownList ID="CategoryDropDown" runat="server"
                        Enabled="false" DataSourceID="CategoryDataSource" SelectedValue="<%# Item.CategoryID %>" DataTextField="CategoryName" DataValueField="CategoryID">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty Per Unit" SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Min Order Qty" SortExpression="MinimumOrderQuantity"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit $" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="On Order" SortExpression="UnitsOnOrder"></asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Disc." SortExpression="Discontinued"></asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListProducts" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="CategoryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategory" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="SupplierDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
