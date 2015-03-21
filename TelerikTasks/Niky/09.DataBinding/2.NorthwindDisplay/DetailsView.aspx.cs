using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.NorthwindDisplay
{
    public partial class DetailsView : System.Web.UI.Page
    {
		int employeeId;
		Employees employee;
		NorthwindEntities1 database;

        protected void Page_Load(object sender, EventArgs e)
        {
			if (int.TryParse(Request.Params["id"], out employeeId))
			{
				database = new NorthwindEntities1();
				var employees = from p in database.Employees where p.EmployeeID == employeeId select p;

				if (employees.Count() == 1)
				{
					DetailsViewEmployees.DataSource = employees;
					DetailsViewEmployees.DataBind();
				}
				else
				{
					Response.Redirect("~/Default.aspx", true);
				}
			}
			else
			{
				Response.Redirect("~/Default.aspx", true);
			}
        }
    }
}