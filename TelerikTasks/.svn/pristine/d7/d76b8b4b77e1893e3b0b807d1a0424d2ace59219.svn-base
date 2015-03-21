using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task06
{
	enum Operations { None, Divide, Multiply, Minus, Plus };
	public partial class Task06 : System.Web.UI.Page
	{
		private float lastNumber;
		private Operations operation = Operations.None;

		public string CurrentText
		{
			get
			{
				return TextBoxScreen.Text;
			}
			set
			{
				TextBoxScreen.Text = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session.Contents["currentText"] == null)
			{
				Session.Add("currentText", CurrentText);
				Session.Add("lastNumber", lastNumber);
				Session.Add("operation", operation);
			}
			else
			{
				CurrentText = Session.Contents["currentText"].ToString();
				lastNumber = (float)Session.Contents["lastNumber"];
				operation = (Operations)Session.Contents["operation"];
			}

			if (string.IsNullOrEmpty(CurrentText))
			{
				CurrentText = "0";
			}
		}

		protected void ButtonBackspaceClick(object sender, EventArgs e)
		{
			if (CurrentText.Length > 0)
			{
				CurrentText = CurrentText.Remove(CurrentText.Length - 1);
			}

			SaveDataToSession();
		}

		private void SaveDataToSession()
		{
			Session.Contents["currentText"] = CurrentText;
			Session.Contents["lastNumber"] = lastNumber;
			Session.Contents["operation"] = operation;
		}

		protected void ButtonCClick(object sender, EventArgs e)
		{
			CurrentText = "0";
			lastNumber = 0;
			SaveDataToSession();
		}

		protected void ButtonChangeSignClick(object sender, EventArgs e)
		{
			CurrentText = (float.Parse(CurrentText) * -1).ToString();
			SaveDataToSession();
		}

		protected void ButtonSqrtClick(object sender, EventArgs e)
		{
			CurrentText = (Math.Sqrt(float.Parse(CurrentText))).ToString();
			SaveDataToSession();
		}

		protected void Button7Click(object sender, EventArgs e)
		{
			CurrentText += '7';
			SaveDataToSession();
		}

		protected void Button8Click(object sender, EventArgs e)
		{
			CurrentText += '8';
			SaveDataToSession();
		}

		protected void Button9Click(object sender, EventArgs e)
		{
			CurrentText += '9';
			SaveDataToSession();
		}

		protected void ButtonDivideClick(object sender, EventArgs e)
		{
			lastNumber = float.Parse(CurrentText);
			operation = Operations.Divide;
			CurrentText = "0";
			SaveDataToSession();
		}

		protected void Button4Click(object sender, EventArgs e)
		{
			CurrentText += '4';
			SaveDataToSession();
		}

		protected void Button5Click(object sender, EventArgs e)
		{
			CurrentText += '5';
			SaveDataToSession();
		}

		protected void Button6Click(object sender, EventArgs e)
		{
			CurrentText += '6';
			SaveDataToSession();
		}

		protected void ButtonMultiplyClick(object sender, EventArgs e)
		{
			lastNumber = float.Parse(CurrentText);
			operation = Operations.Multiply;
			CurrentText = "0";
			SaveDataToSession();
		}

		protected void ButtonEqualsClick(object sender, EventArgs e)
		{
			if (operation != Operations.None)
			{
				switch (operation)
				{
					case Operations.Divide:
						{
							CurrentText = string.Format("{0:0.00000}", lastNumber / float.Parse(CurrentText));
						}
						break;
					case Operations.Minus:
						{
							CurrentText = string.Format("{0:0.00000}", lastNumber - float.Parse(CurrentText));
						}
						break;
					case Operations.Multiply:
						{
							CurrentText = string.Format("{0:0.00000}", lastNumber * float.Parse(CurrentText));
						}
						break;
					case Operations.Plus:
						{
							CurrentText = string.Format("{0:0.00000}", lastNumber + float.Parse(CurrentText));
						}
						break;
				}
			}
			SaveDataToSession();
		}

		protected void Button1Click(object sender, EventArgs e)
		{
			CurrentText += '1';
			SaveDataToSession();
		}

		protected void Button2Click(object sender, EventArgs e)
		{
			CurrentText += '2';
			SaveDataToSession();
		}

		protected void Button3Click(object sender, EventArgs e)
		{
			CurrentText += '3';
			SaveDataToSession();
		}

		protected void ButtonMinusClick(object sender, EventArgs e)
		{
			lastNumber = float.Parse(CurrentText);
			CurrentText = "0";
			operation = Operations.Minus;
			SaveDataToSession();
		}

		protected void Button0Click(object sender, EventArgs e)
		{
			if (float.Parse(CurrentText) != 0)
			{
				CurrentText += '0';
			}
			SaveDataToSession();
		}

		protected void ButtonCommaClick(object sender, EventArgs e)
		{
			CurrentText += ',';
			SaveDataToSession();
		}

		protected void ButtonPlusClick(object sender, EventArgs e)
		{
			lastNumber = float.Parse(CurrentText);
			CurrentText = "0";
			operation = Operations.Plus;
			SaveDataToSession();
		}
	}
}