using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Models.Models.Options;
using Models.Models.Tests;
using TestApplication.Tests;
using TestApplication.Options;
using Models.Logic;
using Models.Models.Help;
using TestApplication.Help;

namespace TestApplication
{
	public class MainViewModel : ViewModelBase
	{
		private MainModel model;
		private RelayCommand browseForSourceCode;
		private RelayCommand browseForTestsImputsFolder;
		private RelayCommand browseForExpectedOutputFolder;
		private RelayCommand runTest;
		private RelayCommand closeCommand;
		private RelayCommand showOptionsWindow;
		private RelayCommand showAboutWindow;
		private List<TestsResultsViewModel> allTests;
		Configuration config;

		public string TaskName
		{
			get { return model.TaskName; }
			set { model.TaskName = value; }
		}

		public string SourceCodePath
		{
			get
			{
				return model.SourceCodePath;
			}
			set
			{
				model.SourceCodePath = value;
				OnPropertyChanged("SourceCodePath");
			}
		}

		public string TestsImputsFolderPath
		{
			get
			{
				return model.TestsResultsFolderPath;
			}
			private set
			{
				model.TestsResultsFolderPath = value;
				OnPropertyChanged("TestsImputsFolderPath");
			}
		}

		public string ExpectedOutputFolder
		{
			get { return model.ExpectedOutputFolder; }
			set
			{
				model.ExpectedOutputFolder = value;
				OnPropertyChanged("ExpectedOutputFolder");
			}
		}

		public ICommand BrowseForSourceCode
		{
			get
			{
				if (browseForSourceCode == null)
				{
					browseForSourceCode = new RelayCommand(
						param => BrowseForSourceCodeMethod(),
						param => CanBrowseForSourceCode
						);
				}
				return browseForSourceCode;
			}
		}

		public ICommand BrowseForTestsImputsFolderPath
		{
			get
			{
				if (browseForTestsImputsFolder == null)
				{
					browseForTestsImputsFolder = new RelayCommand(
						param => BrowseForTestsImputsFolderMethod(),
						param => CanBrowseForTestsImputsFolder
						);
				}
				return browseForTestsImputsFolder;
			}
		}

		public ICommand BrowseForExpectedOutputFolder
		{
			get
			{
				if (browseForExpectedOutputFolder == null)
				{
					browseForExpectedOutputFolder = new RelayCommand(
						param => BrowseForExpectedOutputFolderMethod(),
						param => CanBrowseForExpectedOutputFolder
						);
				}
				return browseForExpectedOutputFolder;
			}
		}

		public ICommand RunTest
		{
			get
			{
				if (runTest == null)
				{
					runTest = new RelayCommand(
						param => RunTestMethod(),
						param => CanRunTest
						);
				}
				return runTest;
			}
		}

		public ICommand ShowOptionsWindow
		{
			get
			{
				if (showOptionsWindow == null)
				{
					showOptionsWindow = new RelayCommand(
						param => ShowOptionsWindowMethod(),
						param => CanShowOptionsWindowMethod
						);
				}
				return showOptionsWindow;
			}
		}

		public ICommand ShowAboutWindow
		{
			get
			{
				if (showAboutWindow == null)
				{
					showAboutWindow = new RelayCommand(
						param => ShowAboutWindowMethod(),
						param => CanShowAboutWindowMethod
						);
				}
				return showAboutWindow;
			}
		}

		/// <summary>
		/// Returns the command that, when invoked, attempts
		/// to remove this workspace from the user interface.
		/// </summary>
		public ICommand CloseCommand
		{
			get
			{
				if (closeCommand == null)
					closeCommand = new RelayCommand(param => this.OnRequestClose());

				return closeCommand;
			}
		}

		public List<TestsResultsViewModel> AllTests
		{
			get
			{
				allTests = new List<TestsResultsViewModel>();
				foreach (TestsResultsModel testsResultsModel in model.AllTests)
				{
					allTests.Add(new TestsResultsViewModel(testsResultsModel));
				}
				return allTests;
			}
		}

		public MainViewModel(MainModel model)
		{
			this.model = model;
			config = new Configuration();
		}

		private bool CanBrowseForSourceCode
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.TaskName);
			}
		}

		private bool CanBrowseForTestsImputsFolder
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.SourceCodePath);
			}
		}

		private bool CanBrowseForExpectedOutputFolder
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.TestsImputsFolderPath);
			}
		}

		private bool CanRunTest
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.ExpectedOutputFolder);
			}
		}

		private bool CanShowOptionsWindowMethod
		{
			get 
			{
				return true;
			}
		}

		private bool CanShowAboutWindowMethod
		{
			get
			{
				return true;
			}
		}

		private void BrowseForSourceCodeMethod()
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "C# Source Code|*.cs";
            openFile.FileName = Path.GetFileName(config.SourceCodePath);
            openFile.InitialDirectory = Path.GetDirectoryName(config.SourceCodePath);

            if (openFile.ShowDialog() == DialogResult.OK)
			{
				this.SourceCodePath = openFile.FileName;
				config.SourceCodePath = this.SourceCodePath;
			}
		}

		private void BrowseForTestsImputsFolderMethod()
		{
			FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
			folderSelectDialog.SelectedPath = config.TestsImputsFolderPath;

			if (folderSelectDialog.ShowDialog() == DialogResult.OK)
			{
				this.TestsImputsFolderPath = folderSelectDialog.SelectedPath;
				config.TestsImputsFolderPath = this.TestsImputsFolderPath;
			}
		}

		private void BrowseForExpectedOutputFolderMethod()
		{
			FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
			folderSelectDialog.SelectedPath = config.ExpectedOutputFolder;

			if (folderSelectDialog.ShowDialog() == DialogResult.OK)
			{
				this.ExpectedOutputFolder = folderSelectDialog.SelectedPath;
				config.ExpectedOutputFolder = this.ExpectedOutputFolder;
			}
		}

		private void RunTestMethod()
		{
			model.RunAllTests();
			OnPropertyChanged("AllTests");
		}

		private void ShowOptionsWindowMethod()
		{
			OptionsModel model = new OptionsModel();
			OptionsViewModel viewModel = new OptionsViewModel(model);

			OptionsWindow view = new OptionsWindow();
			view.DataContext = viewModel;

			view.ShowDialog();
		}

		private void ShowAboutWindowMethod()
		{
			AboutModel model = new AboutModel();
			AboutViewModel viewModel = new AboutViewModel(model);

			About view = new About();
			view.DataContext = viewModel;

			view.ShowDialog();
		}
	}
}
