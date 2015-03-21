using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Models.Models.Options;

namespace Models.Models.Tests
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel model;
        private RelayCommand browseForSourceCode;
        private RelayCommand browseForTestsFolder;
        private RelayCommand browseForExpectedOutputFolder;
        private RelayCommand runTest;
        private RelayCommand closeCommand;
        private ObservableCollection<TestsResultsViewModel> allTests;

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
            }
        }

        public string TestsFolderPath
        {
            get
            {
                return model.TestsFolderPath;
            }
            private set
            {
                model.TestsFolderPath = value;
                OnPropertyChanged("TestsFolderPath");
            }
        }

        public string ExpectedOutputFolder
        {
            get { return model.ExpectedOutputFolder; }
            set { model.ExpectedOutputFolder = value; }
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

        public ICommand BrowseForTestsFolder
        {
            get
            {
                if (browseForTestsFolder == null)
                {
                    browseForTestsFolder = new RelayCommand(
                        param => BrowseForTestsFolderMethod(),
                        param => CanBrowseForTestsFolder
                        );
                }
                return browseForTestsFolder;
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

        public ObservableCollection<TestsResultsViewModel> AllTests
        {
            get
            {
                if (allTests == null)
                {
                    allTests = new ObservableCollection<TestsResultsViewModel>();
                    foreach (TestsResultsModel testsResultsModel in model.AllTests)
                    {
                        allTests.Add(new TestsResultsViewModel(testsResultsModel));
                    }
                }
                return allTests;
            }
        }

        public MainViewModel(MainModel model)
        {
            this.model = model;
        }

        private bool CanBrowseForSourceCode
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.TaskName);
            }
        }

        private bool CanBrowseForTestsFolder
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
                return !string.IsNullOrWhiteSpace(this.TestsFolderPath);
            }
        }

        private bool CanRunTest
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.ExpectedOutputFolder);
            }
        }

        private void BrowseForSourceCodeMethod()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "C# Source Code|*.cs";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.SourceCodePath = openFile.FileName;
                OnPropertyChanged("SourceCodePath");
            }
        }

        private void BrowseForTestsFolderMethod()
        {
            FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK)
            {
                this.TestsFolderPath = folderSelectDialog.SelectedPath;
                OnPropertyChanged("TestsFolderPath");
            }
        }

        private void BrowseForExpectedOutputFolderMethod()
        {
            FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK)
            {
                this.ExpectedOutputFolder = folderSelectDialog.SelectedPath;
                OnPropertyChanged("ExpectedOutputFolder");
            }
        }

        private void RunTestMethod()
        {
            model.RunAllTests();
        }

		private void ShowOptionsWindowMethod()
		{
			OptionsModel model = new OptionsModel();
			OptionsViewModel viewModel = new OptionsViewModel(model);
		}
    }
}
