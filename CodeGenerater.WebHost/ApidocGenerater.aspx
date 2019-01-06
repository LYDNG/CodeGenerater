<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApidocGenerater.aspx.cs" Inherits="CodeGenerater.WebHost.ApidocGenerater" %>

<%@ Import Namespace="ApidocGenerater.Core" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            api名称：<asp:TextBox ID="tbxName" runat="server" Width="456px"></asp:TextBox>
            <br />
            api本机路径：<asp:TextBox ID="tbxLocalPath" runat="server" Width="456px"></asp:TextBox>
            <br />
            <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="生成" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td style="font-size: 14pt; font-family: 微软雅黑; line-height: 38px;"><%=ApiName %> <span style="font-size:13px;color:gray">(<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>)</span>
                    </td>
                </tr>
                <%
                    foreach (ApidocGenerater.Core.Entity.ContractApi contract in Doc.Contracts)
                    {
                %>
                <tr>
                    <td style="color: #369; font-size: 14px; padding-left: 12px; font-family: 宋体; line-height: 28px;">
                        <div>
                            &middot;<%=contract.Name %>
                        </div>
                        <div style="color: black; padding-left: 13px; padding-bottom: 10px;">
                            <%=contract.Comments %>
                        </div>
                    </td>
                </tr>
                <%
                    }
                %>
            </table>

        </div>
    </form>
</body>
</html>
