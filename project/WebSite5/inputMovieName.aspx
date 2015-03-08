<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inputMovieName.aspx.cs" Inherits="inputMovieName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Movie Name:
    
    </div>
    <p>
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    </asp:GridView>
    </form>
</body>
</html>
