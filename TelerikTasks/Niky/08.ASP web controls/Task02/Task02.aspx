<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task02.aspx.cs" Inherits="Task01.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblLowerBound" runat="server" Text="Generate random number between:"></asp:Label>
    
        <asp:TextBox ID="txtLowerBound" runat="server"></asp:TextBox>
        <asp:Label ID="lblUpperBound" runat="server" Text="and:"></asp:Label>
    
        <asp:TextBox ID="txtUpperBound" runat="server"></asp:TextBox>
    
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" 
            onclick="btnGenerate_Click" />
    
        <br />
        <asp:Label ID="lblResult" runat="server" Text="Random number:"></asp:Label>
        <asp:TextBox ID="txtResult" runat="server" Enabled="False"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
