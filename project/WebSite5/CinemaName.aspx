<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CinemaName.aspx.cs" Inherits="CinemaName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Cinema Name:</div>
    <asp:TextBox ID="TextBox1" runat="server" Height="20px" 
        ontextchanged="TextBox1_TextChanged" Width="133px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    </form>
</body>
</html>
