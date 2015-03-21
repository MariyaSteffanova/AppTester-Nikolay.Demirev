<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task04.aspx.cs" Inherits="Task04.Task04" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelFirstName" runat="server" Text="First name:"></asp:Label>
        <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelLastName" runat="server" Text="Last name:"></asp:Label>
        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty number:"></asp:Label>
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelUniversity" runat="server" Text="University:"></asp:Label>
        <asp:DropDownList ID="DropDownListUniversity" runat="server" 
            onselectedindexchanged="UniversityChanged" AutoPostBack="true">
            <asp:ListItem Selected="True">--Select one--</asp:ListItem>
            <asp:ListItem>TU-Sofia</asp:ListItem>
            <asp:ListItem>UNSS</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="LabelSpecialty" runat="server" Text="Specialty:"></asp:Label>
        <asp:DropDownList ID="DropDownListSpecialty" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LabelCourses" runat="server" Text="Courses:"></asp:Label>
        <asp:ListBox ID="ListBoxCourses" runat="server" Height="158px" 
            SelectionMode="Multiple" Width="126px">
            <asp:ListItem>Web design</asp:ListItem>
            <asp:ListItem>.Net</asp:ListItem>
            <asp:ListItem>High quality code</asp:ListItem>
        </asp:ListBox>
    
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
            onclick="ButtonSubmit_Click" />
    
    </div>
    </form>
</body>
</html>
