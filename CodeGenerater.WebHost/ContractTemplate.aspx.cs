using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeGenerater.WebHost
{
    public partial class ContractTemplate : System.Web.UI.Page
    {
        protected string Comments = string.Empty;
        protected string ContractName = string.Empty;
        protected string NameSpace = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            this.Comments = this.tbComments.Text;
            this.ContractName = this.tbContractName.Text;
            this.NameSpace = this.tbNameSpace.Text;
        }
    }
}