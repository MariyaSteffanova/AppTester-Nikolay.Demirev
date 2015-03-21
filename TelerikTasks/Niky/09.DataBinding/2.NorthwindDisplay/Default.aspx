<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="_2.NorthwindDisplay._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Telerik academy
    </h2>
    <h3>Northwind Employees</h3>
    <p>
        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
            <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="EmployeeID"
                 DataNavigateUrlFormatString="~/DetailsView.aspx?id={0}"
                 DataTextField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            </Columns>
        </asp:GridView>
    </p>
    
</asp:Content>
