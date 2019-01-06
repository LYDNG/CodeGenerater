using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCodeGenerater.Core;
using MyCodeGenerater.Core.Entity;

namespace CodeGenerater.WebHost
{
    public partial class EntityTemplate : System.Web.UI.Page
    {
        protected TableEntity DBTable = new TableEntity() { 
            Columns=new List<ColumnEntity>(),
            Comments="N/A",
            Name="UNTABLE"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            string ConncectionString = this.tbConnectString.Text;
            string TableName = this.tbTable.Text.ToUpper();
            GeneraterFacade facade = new GeneraterFacade(ConncectionString);


            string sql = "SELECT s.COLUMN_NAME,s.DATA_TYPE,s.DATA_SCALE FROM User_Tab_Cols s WHERE  s.table_name='" + TableName + "'";

            
            DBTable = facade.GetTable(TableName);
        }
    }
}