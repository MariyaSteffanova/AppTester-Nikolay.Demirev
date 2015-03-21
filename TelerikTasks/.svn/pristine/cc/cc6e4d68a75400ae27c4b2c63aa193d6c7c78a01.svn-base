using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task05
{
	public partial class Task05 : System.Web.UI.Page
	{
		List<int> lstEmptyFields;
		List<ImageButton> lstButtons;
		Random rnd = new Random();
		char[,] boardState; 

		protected void Page_Load(object sender, EventArgs e)
		{
			ViewStateMode = System.Web.UI.ViewStateMode.Enabled;

			lstButtons = new List<ImageButton>();
			lstButtons.Add(ImageButton1);
			lstButtons.Add(ImageButton2);
			lstButtons.Add(ImageButton3);
			lstButtons.Add(ImageButton4);
			lstButtons.Add(ImageButton5);
			lstButtons.Add(ImageButton6);
			lstButtons.Add(ImageButton7);
			lstButtons.Add(ImageButton8);
			lstButtons.Add(ImageButton9);

			if (Session.Contents["lstEmptyFields"] == null)
			{
				lstEmptyFields = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
				boardState = new char[3, 3];

				Session.Add("lstEmptyFields", lstEmptyFields);
				Session.Add("boardState", boardState);
			}
			else
			{
				lstEmptyFields = (List<int>)Session.Contents["lstEmptyFields"];
				boardState = (char[,])Session.Contents["boardState"];
			}
		}

		protected void ImageButton_Click(object sender, ImageClickEventArgs e)
		{
			if (((ImageButton)sender).ImageUrl.Contains("none") && !IsSomeoneWinnig())
			{
				((ImageButton)sender).ImageUrl = ((ImageButton)sender).ImageUrl.Replace("none", "x");

				char fieldNumber = ((ImageButton)sender).ID.Last();
				int fieldIndex = fieldNumber - '0' - 1;

				boardState[fieldIndex / 3, fieldIndex % 3] = 'x';

				lstEmptyFields.Remove(fieldIndex);

				if (IsSomeoneWinnig())
				{
					Session.Clear();
					return;
				}

				if (lstEmptyFields.Count > 0)
				{
					int randomFieldNumber = rnd.Next(0, lstEmptyFields.Count);

					lstButtons[lstEmptyFields[randomFieldNumber]].ImageUrl = lstButtons[lstEmptyFields[randomFieldNumber]].ImageUrl.Replace("none", "o");

					boardState[lstEmptyFields[randomFieldNumber] / 3, lstEmptyFields[randomFieldNumber] % 3] = 'o';

					lstEmptyFields.RemoveAt(randomFieldNumber);

					Session.Contents["lstEmptyFields"] = lstEmptyFields;
					Session.Contents["boardState"] = boardState;
				}

				if (IsSomeoneWinnig())
				{
					Session.Clear();
					return;
				}
			}
		}

		private bool IsSomeoneWinnig()
		{
			for (int i = 0; i < 3; i++)
			{
				if (boardState[i, 0] != '\0' && boardState[i, 0] == boardState[i, 1] && boardState[i, 1] == boardState[i, 2])
				{
					if (boardState[i, 1] == 'o')
					{
						Response.Write("<h1>The winner is O</h1>");
						return true;
					}
					else
					{
						Response.Write("<h1>The winner is X</h1>");
						return true;
					}
				}
			}

			for (int i = 0; i < 3; i++)
			{
				if (boardState[0, i] != '\0' && boardState[0, i] == boardState[1, i] && boardState[1, i] == boardState[2, i])
				{
					if (boardState[1, i] == 'o')
					{
						Response.Write("<h1>The winner is O</h1>");
						return true;
					}
					else
					{
						Response.Write("<h1>The winner is X</h1>");
						return true;
					}
				}
			}

			if (boardState[1, 1] != '\0' && boardState[0, 0] == boardState[1, 1] && boardState[1, 1] == boardState[2, 2])
			{
				if (boardState[1, 1] == 'o')
				{
					Response.Write("<h1>The winner is O</h1>");
					return true;
				}
				else
				{
					Response.Write("<h1>The winner is X</h1>");
					return true;
				}
			}

			if (boardState[1, 1] != '\0' && boardState[0, 2] == boardState[1, 1] && boardState[1, 1] == boardState[2, 0])
			{
				if (boardState[1, 1] == 'o')
				{
					Response.Write("<h1>The winner is O</h1>");
					return true;
				}
				else
				{
					Response.Write("<h1>The winner is X</h1>");
					return true;
				}
			}

			return false;
		}

		protected void ButtonRestart_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("Task05.aspx", true);
		}
	}
}