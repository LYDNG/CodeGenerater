<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datasync.aspx.cs" Inherits="CodeGenerater.WebHost.Datasync" %>

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
            数据库链接串：<asp:TextBox ID="tbConnectString" runat="server" Width="593px">DATA SOURCE=ZG_TEST;PERSIST SECURITY INFO=True;USER ID=ZG_ERP_TEST;PASSWORD=TEST_111</asp:TextBox>
            <br />
            表名：<asp:TextBox ID="tbTable" runat="server" Width="538px"></asp:TextBox>
            <br />
            <asp:Button ID="btnMake" runat="server" OnClick="btnMake_Click" Text="生成" />
            <br />
            <br />
            <br />
            &lt;!--<%=DBTable.Comments %>--&gt;<br />
            &lt;mapper SubTable=&quot;<%=DBTable.Name %>&quot; SubModel=&quot;<%=DBTable.Name.PascalNameFormat() %>Model&quot; PubTable=&quot;&quot; SubAssembly=&quot;&quot; &gt;<br />
            &nbsp;&nbsp;&lt;columns&gt;<br />
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
                {
            %>
            &nbsp;&nbsp;&nbsp; &lt;column SubField=&quot;<%=entity.Name %>&quot; SubProperty=&quot;<%=entity.Name.PascalNameFormat() %>&quot; PubField=&quot;<%=entity.Name.PascalNameFormat()%>&quot; /&gt;<br />
            <%
                }
            %>
            &nbsp;&nbsp;&lt;/columns&gt;<br />
             &lt;/mapper&gt;<br />
        </div>
    </form>
</body>
</html>
