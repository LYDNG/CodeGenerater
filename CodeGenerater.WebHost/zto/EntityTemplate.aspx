<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityTemplate.aspx.cs" Inherits="CodeGenerater.WebHost.EntityTemplate" %>

<%@ Import Namespace="MyCodeGenerater.Core" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        数据库链接串：<asp:TextBox ID="tbConnectString" runat="server" Width="593px"></asp:TextBox>
        <br />
        表名：<asp:TextBox ID="tbTable" runat="server" Width="538px"></asp:TextBox>
        <br />
        <asp:Button ID="btnMake" runat="server" OnClick="btnMake_Click" Text="生成" />
        <br />
        <br />
        <br />
        /// &lt;summary&gt;<br />
        /// <%=DBTable.Comments %><br />
        /// &lt;summary&gt;<br />
        public class <%=DBTable.Name.PascalNameFormat() %>DTO<br />
        {
        <%
            foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
            { 
        %>
            <br />
            &nbsp;&nbsp;&nbsp; /// &lt;summary&gt;<br />
            &nbsp;&nbsp;&nbsp; /// <%=entity.Comments %>
            <br />
            &nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;<br />
            &nbsp;&nbsp;&nbsp; public <%=entity.CSharpType %> <%=entity.Name.PascalNameFormat() %>{get;set;}<br />
        <%
        }
        
        %>}
        </div>
    </form>
</body>
</html>
