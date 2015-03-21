<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="_5.DisplayWithRepeater._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Telerik Academy
    </h2>
    <p>
    
        <asp:Repeater ID="RepeaterEmployees" runat="server">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background: #FFDDFF">
                   <td><%# Eval("FirstName") %></td>
                   <td><%# Eval("LastName") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background: #00FF00">
                   <td><%# Eval("FirstName") %></td>
                   <td><%# Eval("LastName")%></td>
                </tr>
            </AlternatingItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </p>

    
</asp:Content>
