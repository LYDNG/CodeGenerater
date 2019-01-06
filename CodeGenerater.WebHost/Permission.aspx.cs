using MyCodeGenerater.Core;
using MyCodeGenerater.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeGenerater.WebHost
{
    public partial class Permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string connStr = "DATA SOURCE=ZG_TEST;PERSIST SECURITY INFO=True;USER ID=ZG_ERP_TEST;PASSWORD=TEST_111";
        protected void btnMake_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
            {
                TextBox2.Text = "";
                return;
            }
            string sql = "SELECT * FROM TPERMISSION T WHERE T.PKID IN (SELECT MP.PERMISSIONID FROM TMODULE_PERMISSION MP  WHERE MP.MODULEID IN (SELECT M.PKID  FROM TMODULE M WHERE M.MODULENAME IN (:Name)))";
            string value = TextBox1.Text.Trim();
            GeneraterFacade facade = new GeneraterFacade(connStr);
            DataTable dd = facade.ExecuteDataTable(sql, new Oracle.DataAccess.Client.OracleParameter("Name", value));
            foreach (DataRow item in dd.Rows)
            {
                TextBox2.Text += item["PERMISSION_NAME"].ToString() + Environment.NewLine;
            }
        }
    }
}