<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="_6.ListViewEmployee._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Telerik Academy
    </h2>
    <p>
        <asp:ListView ID="ListViewEmployees" runat="server">
            <LayoutTemplate>
                <h3>Employees</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
        
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <h4><%# Eval("FirstName") + " " + Eval("LastName") %></h4>
            </ItemTemplate>
        </asp:ListView>
    </p>
      
    
</asp:Content>
