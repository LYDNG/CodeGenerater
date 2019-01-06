using MyCodeGenerater.Core;
using MyCodeGenerater.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeGenerater.WebHost
{
    public partial class Datasync : System.Web.UI.Page
    {
        protected TableEntity DBTable = new TableEntity()
        {
            Columns = new List<ColumnEntity>(),
            Comments = "N/A",
            Name = "UNTABLE"
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            string ConncectionString = this.tbConnectString.Text;
            string TableName = this.tbTable.Text;
            GeneraterFacade facade = new GeneraterFacade(ConncectionString);
            DBTable = facade.GetTable(TableName);
        }
    }
}