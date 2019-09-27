<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.OurSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Our Suppliers</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="SupplierRepeater" runat="server">

            </asp:Repeater>

            <asp:ObjectDataSource ID="SupplierSummaryDataSource" runat="server"></asp:ObjectDataSource>
        </div>

    </div>
</asp:Content>
