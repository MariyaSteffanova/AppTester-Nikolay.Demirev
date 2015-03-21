using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Models.Models.Tests.SingleTestResult;
using System.Windows.Media.Imaging;
using System.Data.Linq;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;

namespace TestApplication.Tests.SingleTestResult
{
    public class SingleTestResultViewModel : ViewModelBase
    {
        private SingleTestResultModel model;
        private RelayCommand compareWithExpectedOutput;

        /// <summary>
        /// Gets a value indicating whether this test is passed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this test is passed; otherwise, <c>false</c>.
        /// </value>
        public TestState TestState
        {
            get { return model.TestState; }
        }

		/// <summary>
		/// Gets the test state image.
		/// </summary>
		public Image TestStateImage
		{
			get
			{
				Image buttonIcon = new Image();
				string fullImagePath = null;
                Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

				switch (TestState)
				{
					case TestState.Error:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/Error.png");
							//image = new Binary(System.IO.File.ReadAllBytes("Images/Error.png"));
						}
						break;
					case TestState.MemoryLimit:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/MemoryLimit.png");
						}
						break;
					case TestState.NotPassed:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/NotPassed.png");
						}
						break;
					case TestState.Passed:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/Passed.png");
						}
						break;
					case TestState.TimeLimit:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/TimeLimit.png");
						}
						break;
					case TestState.ToBeTested:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/ToBeTested.png");
						}
						break;
					case TestState.BuildError:
						{
							fullImagePath = System.IO.Path.GetFullPath("Images/BuildError.png");
						}
						break;
				}

				Uri uri = new Uri(fullImagePath);
				BitmapImage bmp = new BitmapImage(uri);
				buttonIcon.Source = bmp;
				buttonIcon.Stretch = Stretch.Uniform;

				return buttonIcon;
			}
		}

		/// <summary>
		/// Gets the used memory in MB.
		/// </summary>
		public float UsedMemoryMB
		{
			get
			{
				return this.model.UsedMemoryMB;
			}
		}

		/// <summary>
		/// Gets the used time in ms.
		/// </summary>
		public double UsedTime
		{
			get
			{
				return this.model.UsedTime;
			}
		}

		/// <summary>
		/// Gets the exception message.
		/// </summary>
		public string ExceptionMessage
		{
			get
			{
				return this.model.ExceptionMessage;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is exception.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is exception; otherwise, <c>false</c>.
		/// </value>
		public string IsException
		{
			get
			{
				return this.model.IsException.ToString();
			}
		}

        /// <summary>
        /// Gets the compare with expected output.
        /// </summary>
        public ICommand CompareWithExpectedOutput
        {
            get
            {
                if (compareWithExpectedOutput == null)
                {
                    compareWithExpectedOutput = new RelayCommand(
                        param => model.CompareWithExpectedOutput(),
                        param => model.CanCompareWithExpectedOutput
                        );
                }
				return compareWithExpectedOutput;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleTestResultViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SingleTestResultViewModel(SingleTestResultModel model)
        {
            this.model = model;
        }
    }
}
