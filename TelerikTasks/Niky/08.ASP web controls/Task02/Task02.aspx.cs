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
		Random rnd = new Random();

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
			int lowerBound = int.Parse(txtLowerBound.Text);
			int upperBound = int.Parse(txtUpperBound.Text);
			txtResult.Text = rnd.Next(lowerBound, upperBound).ToString();
		}
	}
}