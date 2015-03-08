<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropTH.aspx.cs" Inherits="DropTH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Select functionality :</div>
    &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Search Theaters</asp:ListItem>
        <asp:ListItem Value="Distance and time to theater">Distance and time to theater</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
