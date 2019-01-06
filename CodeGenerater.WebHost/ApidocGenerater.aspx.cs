using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using api = ApidocGenerater.Core;

namespace CodeGenerater.WebHost
{
    public partial class ApidocGenerater : System.Web.UI.Page
    {
        protected string ApiName = string.Empty;
        api.GeneraterFacade facade = new api.GeneraterFacade();
        protected api.Entity.DocEntity Doc = new api.Entity.DocEntity()
        {
            Contracts = new List<api.Entity.ContractApi>()
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            ApiName = this.tbxName.Text;
            Doc = facade.GetApiComments(this.tbxLocalPath.Text);
        }
    }
}