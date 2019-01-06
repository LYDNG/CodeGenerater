<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractTemplate.aspx.cs" Inherits="CodeGenerater.WebHost.ContractTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        名称:
        <asp:TextBox ID="tbContractName" runat="server" Width="358px"></asp:TextBox>
        <br />
        契约描述：<asp:TextBox ID="tbComments" runat="server" Width="358px"></asp:TextBox>
        <br />
        命名空间：<asp:TextBox ID="tbNameSpace" runat="server" Width="358px"></asp:TextBox>
        <br />
        <asp:Button ID="btnMake" runat="server" Text="生成" OnClick="btnMake_Click" />
        <br />
        <br />
        <br />
        ===============================Contract部分================================<br />
        <br />
        using System;<br />
        <br />
        using Framework.Zhaogang.Soa.Common;<br />
        namespace <%=NameSpace %><br />
        {<br />
&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;<br />
&nbsp;&nbsp;&nbsp; /// <%=Comments %>
        <br />
&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;<br />
&nbsp;&nbsp;&nbsp; public class <%=ContractName%>Contract : Contract<<%=ContractName%>Request, <%=ContractName%>Response><<%=ContractName%>Request, <%=ContractName%>Response>&lt;<%=ContractName%>Request,<%=ContractName%>Response&gt;<br />
&nbsp;&nbsp;&nbsp; {<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public <%=ContractName%>Contract()<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this.MethodName = &quot;<%=ContractName%>&quot;;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br />
&nbsp;&nbsp;&nbsp; }<br />
        }<br />
        <br />
        <br />
        ===============================Request部分================================<br />
        <br />
        using System;<br />
        <br />
        using Framework.Zhaogang.Soa.Common;<br />
        namespace <%=NameSpace %><br />
        {<br />
&nbsp;&nbsp;&nbsp; public class <%=ContractName%>Request : Request<br />
&nbsp;&nbsp;&nbsp; {<br />
        <br />
&nbsp;&nbsp;&nbsp; }<br />
        }<br />
        <br />
        <br />
        ===============================Response部分================================<br />
        <br />
        using System;<br />
        <br />
        using Framework.Zhaogang.Soa.Common;<br />
        namespace <%=NameSpace %><br />
        {<br />
&nbsp;&nbsp;&nbsp; public class <%=ContractName%>Response : Response<br />
&nbsp;&nbsp;&nbsp; {<br />
        <br />
&nbsp;&nbsp;&nbsp; }<br />
        }<br />
    
    </div>
    </form>
</body>
</html>
