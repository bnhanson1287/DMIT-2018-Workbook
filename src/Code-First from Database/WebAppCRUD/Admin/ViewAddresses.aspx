<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.ViewAddresses" %>

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
                        <th>City / Region / Country</th>
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
                    <asp:LinkButton ID="EditAddess" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">
                        Edit
                    </asp:LinkButton> 
                    <asp:LinkButton ID="DeleteAddess" runat="server" CssClass="btn btn-danger glyphicon glyphicon-remove" OnClientClick="return confirm('Are you sure you want to delete this address?')" CommandName="Delete">
                        Delete
                    </asp:LinkButton>
                </td>
                <td><%# Item.Address%></td>
                <td>
                    <b><%# Item.City%></b>
                    &ndash;
                    <i><%# Item.Region %></i>
                    <br />
                    <%# Item.Country%>
                </td>
                <td>
                   <%# Item.PostalCode %>
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">
                        Add
                    </asp:LinkButton>
                    <asp:LinkButton ID="CancelInsert" runat="server" CssClass="btn btn-default" CommandName="Cancel">
                        Clear
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Text ="<%#BindItem.Address %>" placeholder="Enter an address"/>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text ="<%#BindItem.City %>" placeholder="Enter a city"/>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue="<%# BindItem.AddressID %>">
                        <asp:ListItem Value="">
                            [Select address on file]
                        </asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="Email" runat="server" Text ="<%#BindItem.Email %>" placeholder="Enter email"/>
                </td>
                <td>
                    <asp:DropDownList ID="RegionDropDown" runat="server" DataSourceID="RegionDataSource" AppendDataBoundItems="true" DataTextField="RegionDescription" DataValueField="RegionID" SelectedValue="<%# BindItem.RegionID %>">
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
    <//asp:ListView>
    <asp:ObjectDataSource ID="AddressDataSource" runat="server" DataObjectTypeName="WestWindSystem.Entities.Address" DeleteMethod="DeleteAddress" InsertMethod="AddAddress" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" UpdateMethod="UpdateAddress"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="RegionDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListRegions" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
