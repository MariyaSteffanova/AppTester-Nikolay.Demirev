using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Models.Help
{
	public class AboutModel
	{
		private const string nikysPicturePath = "Images/niky.png";
		private const string stansPicturePath = "Images/stan.png";
		private const string nikysMail = "mailto:nikolay_demirev@anteni.biz";
		private const string stansMail = "mailto:stanislav.vr@gmail.com";

		public string NikysPicturePath
		{
			get
			{
				return nikysPicturePath;
			}
		}

		public string StansPicturePath
		{
			get
			{
				return stansPicturePath;
			}
		}

		public string NikisMail
		{
			get
			{
				return nikysMail;
			}
		}

		public string StansMail
		{
			get
			{
				return stansMail;
			}
		}
	}
}
