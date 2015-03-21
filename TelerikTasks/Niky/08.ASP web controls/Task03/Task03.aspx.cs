using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task03
{
	public partial class Task03 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string text = Server.HtmlEncode(txtInput.Text);
			txtOutput.Text = txtInput.Text;
			lblOutput.Text = text;
		}
	}
}