using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.NorthwindDisplay
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
				NorthwindEntities1 db = new NorthwindEntities1();
                this.GridViewEmployees.DataSource = db.Employees;
                this.GridViewEmployees.DataBind();
            }
        }
    }
}
