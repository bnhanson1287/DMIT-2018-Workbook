<%@ Page Title="Suppliers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="SuppliersListView" runat="server" DataSourceID="SuppliersDataSource" InsertItemPosition="FirstItem" ItemType="WestWindSystem.Entities.Supplier">
        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Supplier ID</th>
                        <th>Company Name</th>
                        <th>Contact</th>
                        <th>Address</th>
                        <th>Phone / Fax</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:LinkButton ID="EditSupplier" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">
                        Edit
                    </asp:LinkButton>
                </td>
                <td><%# Item.CompanyName%></td>
                <td>
                    <b><%# Item.ContactName%></b>
                    &ndash;
                    <i><%# Item.ContactTitle %></i>
                    <br />
                    <%# Item.Email%>
                </td>
                <td>
                    <%# Item.Address.Address1%>
                    <br />
                    <%# Item.Address.City%>
                    <%# Item.Address.Region%>
                    &nbsp;&nbsp;
                    <%# Item.Address.PostalCode%>
                    <br />
                    <%# Item.Address.Country%>
                </td>
                <td>
                    <%# Item.Phone%>
                    <br />
                    <%# Item.Fax%>
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">
                        Add
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="CompanyName" runat="server" Text ="<%#BindItem.CompanyName %>" placeholder="Enter company name"/>
                </td>
                <td>
                    <asp:TextBox ID="Contact" runat="server" Text ="<%#BindItem.ContactName %>" placeholder="Enter contact name"/>
                    <asp:TextBox ID="JobTitle" runat="server" Text ="<%#BindItem.ContactTitle %>" placeholder="Enter job title"/>
                    <br />
                    <asp:TextBox ID="Email" runat="server" Text ="<%#BindItem.Email %>" placeholder="Enter email"/>
                </td>
                <td>
                    <asp:DropDownList ID="AddressDropDown" runat="server" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue="<%# BindItem.AddressID %>">
                        <asp:ListItem Value="">
                            [Select address on file]
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" Text ="<%#BindItem.Phone %>" TextMode="Phone" placeholder="Enter phone #"/>
                <br />
                    <asp:TextBox ID="Fax" runat="server" Text ="<%#BindItem.Fax %>" TextMode="Phone" placeholder="Enter fax #"/>
                </td>
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr class="bg-info">
                <td>
                    <asp:LinkButton ID="UpdateSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-ok" CommandName="Update">
                        Save
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="CompanyName" runat="server" Text ="<%#BindItem.CompanyName %>" placeholder="Enter company name"/>
                </td>
                <td>
                    <asp:TextBox ID="Contact" runat="server" Text ="<%#BindItem.ContactName %>" placeholder="Enter contact name"/>
                    <asp:TextBox ID="JobTitle" runat="server" Text ="<%#BindItem.ContactTitle %>" placeholder="Enter job title"/>
                    <br />
                    <asp:TextBox ID="Email" runat="server" Text ="<%#BindItem.Email %>" placeholder="Enter email"/>
                </td>
                <td>
                    <asp:DropDownList ID="AddressDropDown" runat="server" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue="<%# BindItem.AddressID %>">
                        <asp:ListItem Value="">
                            [Select address on file]
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" Text ="<%#BindItem.Phone %>" TextMode="Phone" placeholder="Enter phone #"/>
                <br />
                    <asp:TextBox ID="Fax" runat="server" Text ="<%#BindItem.Fax %>" TextMode="Phone" placeholder="Enter fax #"/>
                </td>
            </tr>
        </EditItemTemplate>


    </asp:ListView>

    <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Supplier" InsertMethod="AddSupplier" OnInserted="CheckForExceptions" OnUpdated="CheckForExceptions" OnDeleted="CheckForExceptions"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
