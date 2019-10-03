<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.OurSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Our Suppliers</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="SupplierRepeater" runat="server" DataSourceID="SupplierSummaryDataSource" ItemType="WestWindSystem.ReadModels.SupplierSummary">
                <ItemTemplate>
                    <h3><%# Item.CompanyName %></h3>
                    <p><%# Item.ContactName %></p>
                    <i><p><%# Item.Phone %></p></i>
                    <blockquote>
                        <asp:Repeater ID="ProductRepeater" runat="server" DataSource="<%# Item.Products %>" ItemType="WestWindSystem.ReadModels.ProductSummary">
                            <HeaderTemplate>
                                <table class="table table-hover table-condensed">
                            </HeaderTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                            <ItemTemplate>
                                <tr>
                                   <th class="col-md-3"><%# Item.ProductName %></th>
                                   <th class="col-md-3"><%# Item.QuantityPerUnit %></th> 
                                   <th class="col-md-3"><%# $"{Item.UnitPrice:C}" %></th> 
                                   <th class="col-md-3"><%# Item.Category %></th>                                     
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </blockquote>
                </ItemTemplate>
            </asp:Repeater>

            <asp:ObjectDataSource ID="SupplierSummaryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.SupplierController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
