using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Models.Help;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Input;

namespace TestApplication.Help
{
	public class AboutViewModel : ViewModelBase
	{
		private AboutModel model;
		private RelayCommand mailToStan;
		private RelayCommand mailToNiky;


		public Image NikysPicture
		{
			get
			{
				Image picture = new Image();
				string fullImagePath = null;
				fullImagePath = System.IO.Path.GetFullPath(model.NikysPicturePath);

				Uri uri = new Uri(fullImagePath);
				BitmapImage bmp = new BitmapImage(uri);
				picture.Source = bmp;
				picture.Stretch = Stretch.Uniform;

				return picture;
			}
		}

		public Image StansPicture
		{
			get
			{
				Image picture = new Image();
				string fullImagePath = null;
				fullImagePath = System.IO.Path.GetFullPath(model.StansPicturePath);

				Uri uri = new Uri(fullImagePath);
				BitmapImage bmp = new BitmapImage(uri);
				picture.Source = bmp;
				picture.Stretch = Stretch.Uniform;

				return picture;
			}
		}

		public AboutViewModel(AboutModel model)
		{
			this.model = model;
		}

		public ICommand MailToStan
		{
			get
			{
				if (mailToStan == null)
				{
					mailToStan = new RelayCommand(
						param => Mail(model.StansMail),
						param => true
						);
				}
				return mailToStan;
			}
		}

		public ICommand MailToNiky
		{
			get
			{
				if (mailToNiky == null)
				{
					mailToNiky = new RelayCommand(
						param => Mail(model.NikisMail),
						param => true
						);
				}
				return mailToNiky;
			}
		}

		private void Mail(string mail)
		{
			Process.Start(new ProcessStartInfo(new Uri(mail).AbsoluteUri));
		}
	}
}
