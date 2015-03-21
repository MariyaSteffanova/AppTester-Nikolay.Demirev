using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task01
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ButtonGenerateClick(object sender, EventArgs e)
		{
			Random rnd = new Random();
			int lowerBound = int.Parse(txtLowerBound.Value);
			int upperBound = int.Parse(txtUpperBound.Value);
			txtResult.Value = rnd.Next(lowerBound, upperBound).ToString();
		}
	}
}