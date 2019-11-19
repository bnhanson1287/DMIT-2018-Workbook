<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.Sales.OrderShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Order Shipping</h1>

    <div class="row">
        <div class="col-md-12">
            <p>
                <asp:Literal runat="server" ID="SupplierInfo"/>
            </p>
            <asp:ListView ID="CurrentOrders" runat="server" DataSourceID="SuppliersOrdersDataSource" ItemType="WestWindSystem.DataModels.OutstandingOrder" OnItemCommand="CurrentOrders_ItemCommand">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            (<asp:Label Text='<%#Item.OrderId %>' runat="server" ID="OrderIdLabel" />)
                            <%# Item.ShipToName %>
                        </td>
                        <td>
                            <%# Item.OrderDate.ToString("MMM dd, yyyy") %>

                        </td>
                        <td>
                            <%# Item.RequiredBy.ToString("MMM dd, yyyy") %> - in <%#Item.DaysRemaining %>
                        </td>
                        <td>
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Cancel" CssClass="btn btn-default">
                               Close
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="OrderComments" runat="server" text="<%# Item.Comments %>"/>
                            <asp:DropDownList ID="ShipperDropDown" runat="server" CssClass="form-control" DataSourceID="ShippersDataSource" DataTextField="Shipper" DataValueField="ShipperId" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Select a Shipper</asp:ListItem>
                            </asp:DropDownList>
                            <asp:GridView ID="ProductsGridView" runat="server" DataSource="<%#Item.OutstandingItems%>" ItemType="WestWindSystem.DataModels.OrderItem" CssClass="table table-hover
                                table-condensed" AutoGenerateColumns="false" DataKeyNames="ProductID">
                                <Columns>
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="QtyPerUnit" HeaderText="Qty per Unit" />
                                    <asp:BoundField DataField="Outstanding" HeaderText="Outstanding" />
                                    <asp:TemplateField HeaderText="Ship Quantity">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="ProductId" runat="server" Value="<%#Item.ProductId %>" />
                                            <asp:TextBox ID="ShipQuantity" runat="server"></asp:TextBox> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="ShippingAddress" runat="server" text=<%# Item.FullShippingAddress %>/>
                            <asp:TextBox ID="TrackingCode" runat="server" />
                            <asp:TextBox ID="FreightCharge" runat="server" />
                            <asp:LinkButton ID="ShipOrder" runat="server" CommandName="Ship" CssClass="btn btn-info">  
                                Ship Order
                            </asp:LinkButton>
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            (<%#Item.OrderId %>)
                            <%# Item.ShipToName %>

                        </td>
                        <td>
                            <%# Item.OrderDate.ToString("MMM dd, yyyy") %> 

                        </td>
                           
                        <td>
                            <%# Item.RequiredBy.ToString("MMM dd, yyyy") %> - in <%#Item.DaysRemaining %>
                        </td>
                        <td>
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Edit" CssClass="btn btn-default">
                                Order Details
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">ShipToName</th>
                                        <th runat="server">OrderDate</th>
                                        <th runat="server">RequiredBy</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ShippersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ShipperList" TypeName="WestWindSystem.BLL.OrderProcessingController"></asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server" ID="SuppliersOrdersDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadOrders" TypeName="WestWindSystem.BLL.OrderProcessingController">
                <SelectParameters>
                    <asp:Parameter Name="supplierID" Type="Int32" DefaultValue="8"></asp:Parameter>

                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
