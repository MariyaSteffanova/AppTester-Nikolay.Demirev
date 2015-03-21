
<%@ Page Title="Details View" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DetailsView.aspx.cs" Inherits="_2.NorthwindDisplay.DetailsView" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <p>
        <asp:DetailsView ID="DetailsViewEmployees" runat="server">
        </asp:DetailsView>
    </p>
</asp:Content>