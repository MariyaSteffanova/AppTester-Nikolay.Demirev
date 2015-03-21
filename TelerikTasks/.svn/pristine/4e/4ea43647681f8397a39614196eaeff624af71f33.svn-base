using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task04
{
	public partial class Task04 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void UniversityChanged(object sender, EventArgs e)
		{
			if (((DropDownList)sender).SelectedValue == "TU-Sofia")
			{
				DropDownListSpecialty.Items.Add("Automatics");
				DropDownListSpecialty.Items.Add("Computer systems and technologies");
				DropDownListSpecialty.Items.Add("Informatics");
			}
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Response.Write("<h3>First Name:</h3>");
			Response.Write(TextBoxFirstName.Text);
			Response.Write("<h3>Last Name:</h3>");
			Response.Write(TextBoxLastName.Text);
			Response.Write("<h3>Faculty number:</h3>");
			Response.Write(TextBoxFacultyNumber.Text);
			Response.Write("<h3>University:</h3>");
			Response.Write(DropDownListUniversity.SelectedValue);
			Response.Write("<h3>Specialty:</h3>");
			Response.Write(DropDownListSpecialty.SelectedValue);
			Response.Write("<h3>Courses:</h3>");
			foreach (ListItem item in ListBoxCourses.Items)
			{
				if (item.Selected)
				{
					Response.Write(item.Value + "<br />");
				}
			}
		}
	}
}