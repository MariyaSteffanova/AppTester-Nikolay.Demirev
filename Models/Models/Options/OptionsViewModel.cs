using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;

namespace Models.Models.Options
{
	public class OptionsViewModel : ViewModelBase
	{
		private OptionsModel model;
		private RelayCommand browseForHistoryFolder;
		private RelayCommand browseForTestsResultsFolder;
		private RelayCommand browseForBeyondCompareFolder;

		public string HistoryFolder
		{
			get
			{
				return model.HistoryFolder;
			}
			set
			{
				model.HistoryFolder = value;
			}
		}

		public ICommand BrowseForHistoryFolder
		{
			get
			{
				if (browseForHistoryFolder == null)
				{
					browseForHistoryFolder = new RelayCommand(
						param => BrowseForHistoryFolderMethod(),
						param => CanBrowseForHistoryFolder
						);
				}
				return browseForHistoryFolder;
			}
		}

		public string TestsResultsFolder
		{
			get
			{
				return model.TestsResultsFolder;
			}
			set
			{
				model.TestsResultsFolder = value;
			}
		}

		public ICommand BrowseForTestsResultsFolder
		{
			get
			{
				if (browseForTestsResultsFolder == null)
				{
					browseForTestsResultsFolder = new RelayCommand(
						param => BrowseForTestsResultsFolderMethod(),
						param => CanBrowseForTestsResultsFolder
						);
				}
				return browseForTestsResultsFolder;
			}
		}

		public string BeyondCompareFilePath
		{
			get
			{
				return model.BeyondCompareFilePath;
			}
			set
			{
				model.BeyondCompareFilePath = value;
			}
		}

		public ICommand BrowseForBeyondCompareFilePath
		{
			get
			{
				if (browseForBeyondCompareFolder == null)
				{
					browseForBeyondCompareFolder = new RelayCommand(
						param => BrowseForBeyondCompareFolderMethod(),
						param => CanBrowseForBeyondCompareFolder
						);
				}
				return browseForBeyondCompareFolder;
			}
		}

		public string TimeLimit
		{
			get
			{
				return model.TimeLimit.ToString();
			}
			set
			{
				int timeLimit;
				if (int.TryParse(value, out timeLimit))
				{
					model.TimeLimit = timeLimit;
				}
			}
		}

		public string MemoryLimit
		{
			get
			{
				return model.MemoryLimit.ToString();
			}
			set
			{
				int memoryLimit;
				if (int.TryParse(value, out memoryLimit))
				{
					model.MemoryLimit = memoryLimit;
				}
			}
		}

		private bool CanBrowseForHistoryFolder
		{
			get { return true; }
		}

		private bool CanBrowseForTestsResultsFolder
		{
			get { return true; }
		}

		private bool CanBrowseForBeyondCompareFolder
		{
			get { return true; }
		}

		private void BrowseForHistoryFolderMethod()
		{
			FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
			if (folderSelectDialog.ShowDialog() == DialogResult.OK)
			{
				this.HistoryFolder = folderSelectDialog.SelectedPath;
				OnPropertyChanged("HistoryFolder");
			}
		}

		private void BrowseForTestsResultsFolderMethod()
		{
			FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
			if (folderSelectDialog.ShowDialog() == DialogResult.OK)
			{
				this.TestsResultsFolder = folderSelectDialog.SelectedPath;
				OnPropertyChanged("TestsResultsFolder");
			}
		}

		private void BrowseForBeyondCompareFolderMethod()
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "Application|*.exe";
			if (openFile.ShowDialog() == DialogResult.OK)
			{
				this.BeyondCompareFilePath = openFile.FileName;
				OnPropertyChanged("BeyondCompareFilePath");
			}
		}

		public OptionsViewModel(OptionsModel model)
		{
			this.model = model;
		}
	}
}
