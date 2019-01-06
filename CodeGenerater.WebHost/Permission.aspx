<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="CodeGenerater.WebHost.Permission" %>

<%@ Import Namespace="MyCodeGenerater.Core" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ERP新版菜单权限查询</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="btnMake" runat="server" OnClick="btnMake_Click" Text="查询对应权限" />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="371px" TextMode="MultiLine" Width="680px"></asp:TextBox>
            
        </div>
    </form>
</body>
</html>
