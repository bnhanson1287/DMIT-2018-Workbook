<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.ViewAddresses" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Addresses</h1>

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="AddressListView" runat="server" DataSourceID="AddressDataSource" InsertItemPosition="FirstItem" DataKeyNames="AddressID" ItemType="WestWindSystem.Entities.Address">
        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Address ID</th>
                        <th>Address</th>
                        <th>City | Region | Country</th>
                        <th>Postal Code</th>
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
                    <asp:LinkButton ID="EditAddress" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">
                        Edit
                    </asp:LinkButton>
                    <asp:LinkButton ID="DeleteAddress" runat="server" CssClass="btn btn-danger glyphicon glyphicon-remove" OnClientClick="return confirm('Are you sure you want to delete this address?')" CommandName="Delete">
                        Delete
                    </asp:LinkButton>
                </td>
                <td><%# Item.Address1 %></td>
                <td>
                    <%# Item.City %>
                    <%# Item.Region %>
                    <%# Item.Country%>
                </td>
                <td><%# Item.PostalCode %></td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">
                        Add
                    </asp:LinkButton>
                    <asp:LinkButton ID="CancelInsert" runat="server"  CssClass="btn btn-default" CommandName="Cancel">
                        Clear
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Text="<%# BindItem.Address1 %>" placeholder="Enter an address"/>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text="<%# BindItem.City %>" placeholder="Enter a city" />
                    <asp:TextBox ID="Region" runat="server" Text="<%#BindItem.Region %>" placeholder="Enter a region" />
                    <asp:TextBox ID="Country" runat="server" Text="<%# BindItem.Country %>" placeholder="Enter a country" />
                </td>
                <td>
                    <asp:TextBox ID="PostalCode" runat="server" Text=<%# BindItem.PostalCode %> placeholder ="Enter a postal code" />
                </td>
            </tr> 
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr class="bg-info">
                <td>
                    <asp:LinkButton ID="UpdateAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-ok" CommandName="Update">
                        Save
                    </asp:LinkButton>
                    <asp:LinkButton ID="CancelInsert" runat="server"  CssClass="btn btn-default" CommandName="Cancel">
                        Cancel
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Text="<%# BindItem.Address1 %>" placeholder="Enter an address"/>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text="<%# BindItem.City %>" placeholder="Enter a city" />
                    <asp:TextBox ID="Region" runat="server" Text="<%#BindItem.Region %>" placeholder="Enter a region" />
                    <asp:TextBox ID="Country" runat="server" Text="<%# BindItem.Country %>" placeholder="Enter a country" />
                </td>
                <td>
                    <asp:TextBox ID="PostalCode" runat="server" Text=<%# BindItem.PostalCode %> placeholder ="Enter a postal code" />
                </td>
            </tr> 
        </EditItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Address" DeleteMethod="DeleteAddress" InsertMethod="AddAddress" UpdateMethod="UpdateAddress" OnInserted="CheckForExceptions" OnDeleted="CheckForExceptions" OnUpdated="CheckForExceptions"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="RegionDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListRegions" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
