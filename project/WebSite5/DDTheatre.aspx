<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DDTheatre.aspx.cs" Inherits="DDTheatre" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter current place:</div>
    <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    <br />
    <br />
    Enter cinema name:<br />
    <asp:TextBox ID="TextBox2" runat="server" ontextchanged="TextBox2_TextChanged"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    </asp:GridView>
    <br />
    </form>
</body>
</html>
