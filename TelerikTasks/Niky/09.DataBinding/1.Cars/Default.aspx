<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="_1.Cars._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <fieldset>
        <legend>Cars</legend>
        <p>
            <asp:Label ID="LabelProducer" runat="server" Text="Producer:"></asp:Label>
            <asp:DropDownList ID="DropDownListProducer" runat="server" 
                onselectedindexchanged="DropDownListProducer_SelectedIndexChanged"
                DataTextField="Name" DataValueField="Name" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="LabelModel" runat="server" Text="Model:"></asp:Label>
            <asp:DropDownList ID="DropDownListModel" runat="server" DataTextField="ModelName" DataValueField="ModelName">
            </asp:DropDownList>
        </p>
        <p>
            <asp:CheckBoxList ID="CheckBoxListExtras" runat="server">
                <asp:ListItem>Brand new</asp:ListItem>
                <asp:ListItem>Used</asp:ListItem>
                <asp:ListItem>Dismentled</asp:ListItem>
            </asp:CheckBoxList>
        </p>
        <p>
            <asp:RadioButtonList ID="RadioButtonListEngine" runat="server">
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Send" 
                onclick="ButtonSubmit_Click" />
            
        </p>
    </fieldset>
    <p>
        <asp:Label ID="LabelCarInfo" runat="server" Text="Car:" ForeColor="Black"></asp:Label>
        <asp:Literal ID="LiteralCarInfo" runat="server" Text="Your car info" Mode="Encode"></asp:Literal>
    </p>
</asp:Content>
