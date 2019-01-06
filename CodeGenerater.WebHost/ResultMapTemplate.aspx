<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultMapTemplate.aspx.cs" Inherits="CodeGenerater.WebHost.ResultMapTemplate" %>

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
            &lt;resultMap id=&quot;<%=DBTable.Name.PascalNameFormat() %>Result&quot; class=&quot;<%=DBTable.Name.PascalNameFormat() %>Entity&quot;&gt;<br />
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
                {
            %>
            &nbsp;&nbsp;&nbsp; &lt;result column=&quot;<%=entity.Name %>&quot; property=&quot;<%=entity.Name.PascalNameFormat() %>&quot;/&gt;<br />
            <%
                }
            %>
             &lt;/resultMap&gt;<br />
            <br />
            <br />
            <br />
            <br />
            &lt;!--Insert脚本--&gt;<br />
            &lt;insert id="Insert<%=DBTable.Name %>" parameterClass="<%=DBTable.Name %>Entity"&gt;
            <br />
            &nbsp;&nbsp;&nbsp; INSERT INTO TABLE(<br />
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
                {
            %>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%=entity.Name %><%=DBTable.Columns.FindLast(it => { return true; }) == entity ? "" : ","%><br />
            <%
                }
            %>
&nbsp;&nbsp;&nbsp; )<br />
            &nbsp;&nbsp;&nbsp; VALUES(<br />
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity2 in DBTable.Columns)
                {
            %>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #<%=entity2.Name.PascalNameFormat() %>#<%=DBTable.Columns.FindLast(it => { return true; }) == entity2 ? "" : ","%><br />
            <%
                }
            %>
            &nbsp;&nbsp;&nbsp; )<br />
            &lt;/insert&gt;<br />
            <br />
            <br />
            <br />
            <br />
            &lt;!--Update脚本--&gt;<br />
            &lt;update id="Update脚本<%=DBTable.Name %>" parameterClass="Hashtable"&gt;<br />            
            UPDATE <%=DBTable.Name %><br />
            &nbsp;&nbsp;&nbsp;&lt;dynamic prepend=&quot;SET&quot;&gt;<br />
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
                {
            %>
&nbsp;&nbsp;&nbsp;&nbsp; &lt;isPropertyAvailable property=&quot;<%=entity.Name.PascalNameFormat() %>&quot; prepend=&quot;,&quot;&gt;<%=entity.Name %>=#E.<%=entity.Name.PascalNameFormat() %>#&lt;/isPropertyAvailable&gt;<br />
            <%
                }
            %>            
            &nbsp;&nbsp;&nbsp;&lt;/dynamic&gt;<br />
            WHERE PKID = #E.#<br />
             &lt;/update&gt;<br />

            <br />
            <br />
            <br />
            <br />
            &lt;!--Select脚本--&gt;<br />           
            SELECT 
            <%
                foreach (MyCodeGenerater.Core.Entity.ColumnEntity entity in DBTable.Columns)
                {
            %>
T.<%=entity.Name %><%=DBTable.Columns.FindLast(it => { return true; }) == entity ? "" : ","%><br />
            <%
                }
            %>            
            FROM <%=DBTable.Name %> T<br />
        </div>
    </form>
</body>
</html>
