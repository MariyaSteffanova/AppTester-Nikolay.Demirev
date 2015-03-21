using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Models.Logic;
using Models.Models.Tests.SingleTestResult;

namespace Models.Models.Tests
{
    public class TestsResultsModel
    {
        private ObservableCollection<SingleTestResultModel> testsResults;

        /// <summary>
        /// Gets a value indicating whether all tests are passed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is all tests passed; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllTestsPassed { get; private set; }

        /// <summary>
        /// Gets the time stamp.
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        /// <summary>
        /// Gets the tests results.
        /// </summary>
        public ObservableCollection<SingleTestResultModel> TestsResults
        {
            get
            {
                if (testsResults == null)
                {
                    testsResults = new ObservableCollection<SingleTestResultModel>();
                }
                return testsResults;
            }
        }

        /// <summary>
        /// Gets the input test directory path.
        /// </summary>
        public string InputTestDirectoryPath { get; private set; }

        /// <summary>
        /// Gets or sets the history folder.
        /// </summary>
        /// <value>
        /// The history folder.
        /// </value>
        private string HistoryFolder { get; set; }

        /// <summary>
        /// Gets the result test directory path.
        /// </summary>
        public string ResultTestDirectoryPath
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the beyond compare file path.
        /// </summary>
        public string BeyondCompareFilePath { get; private set; }

        /// <summary>
        /// Gets the source file path.
        /// </summary>
        public string SourceFilePath { get; private set; }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string TaskName { get; private set; }

		/// <summary>
		/// Gets or sets the path to exe.
		/// </summary>
		/// <value>
		/// The path to exe.
		/// </value>
        private string PathToExe { get; set; }

		/// <summary>
		/// Gets the expected output folder.
		/// </summary>
        public string ExpectedOutputFolder { get; private set; }

		/// <summary>
		/// Gets the peak memory usage.
		/// </summary>
		public float PeakMemoryUsage
		{
			get
			{
				float peekMemoryUsage = 0;
				foreach (var test in this.TestsResults)
				{
					if (test.UsedMemoryMB > peekMemoryUsage)
					{
						peekMemoryUsage = test.UsedMemoryMB;
					}
				}

				return peekMemoryUsage;
			}
		}

		/// <summary>
		/// Gets the peak time usage.
		/// </summary>
		public double PeakTimeUsage
		{
			get
			{
				double peekTimeUsage = 0;
				foreach (var test in this.TestsResults)
				{
					if (test.UsedTime > peekTimeUsage)
					{
						peekTimeUsage = test.UsedTime;
					}
				}

				return peekTimeUsage;
			}
		}

        /// <summary>
        /// Gets or sets the memory limit.
        /// </summary>
        /// <value>
        /// The memory limit.
        /// </value>
        private int MemoryLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time limit.
        /// </summary>
        /// <value>
        /// The time limit.
        /// </value>
        private int TimeLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsResultsModel"/> class.
        /// </summary>
        /// <param name="inputTestDirectoryPath">The input test directory path.</param>
        /// <param name="historyFolder">The history folder.</param>
        /// <param name="resultTestDirectoryPath">The result test directory path.</param>
        /// <param name="beyondCompareFilePath">The beyond compare file path.</param>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="timeLimit">The time limit.</param>
        /// <param name="memoryLimit">The memory limit.</param>
        public TestsResultsModel(string expectedOutputFolder, string inputTestDirectoryPath, string sourceFilePath, string taskName, Configuration configuration)
        {
            this.ExpectedOutputFolder = expectedOutputFolder;
            this.InputTestDirectoryPath = inputTestDirectoryPath;
            this.HistoryFolder = configuration.HistoryFolder;
            this.TaskName = taskName;

            string date = string.Format("{0}.{1}.{2}_{3}-{4}-{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string resultTestDirectoryPath = Path.Combine(configuration.TestsImputsFolderPath, this.TaskName, date);

            this.ResultTestDirectoryPath = resultTestDirectoryPath;
            this.BeyondCompareFilePath = configuration.BeyondCompareFilePath;
            this.SourceFilePath = sourceFilePath;
            this.TimeLimit = configuration.TimeLimit;
            this.MemoryLimit = configuration.MemoryLimit;

            this.TimeStamp = DateTime.Now;
            this.IsAllTestsPassed = false;

            this.PathToExe = string.Format("{0}{1}{2}", Directory.GetParent(this.HistoryFolder).ToString(), TaskName, ".exe");

            this.CreateResultTestsFolder();
            this.InitTests();
        }

        /// <summary>
        /// Runs all tests.
        /// </summary>
        public void RunAllTests()
        {
            if (this.BuildSourceCode())
            {
                foreach (SingleTestResultModel test in testsResults)
                {
                    test.RunTest();
                }
            }
            else
            {
                foreach (SingleTestResultModel test in testsResults)
                {
                    test.SetStateToBuildError();
                }
            }
        }

        /// <summary>
        /// Builds the source code.
        /// </summary>
        private bool BuildSourceCode()
        {
            Compiler compiler = new Compiler(this.SourceFilePath, this.PathToExe);

            // TODO: If there is exception show it somewhere
            bool result = compiler.Compile();

            return result;
        }

        /// <summary>
        /// Inits the tests.
        /// </summary>
        private void InitTests()
        {
            string[] testFiles = Directory.GetFiles(this.InputTestDirectoryPath, "*.in.txt", SearchOption.TopDirectoryOnly);

            foreach (string fileName in testFiles)
            {
                string outputFileName = Path.GetFileName(fileName);
                outputFileName = outputFileName.Replace("in", "out");

                string resultsFilePath = Path.Combine(this.ResultTestDirectoryPath, outputFileName);

                string expectedOutputFileName = Path.GetFileName(fileName);
                expectedOutputFileName = expectedOutputFileName.Replace("in", "out");

                string expectedOutputFilePath = Path.Combine(this.ExpectedOutputFolder, expectedOutputFileName);

                TestsResults.Add(new SingleTestResultModel(fileName, resultsFilePath, expectedOutputFilePath, this.BeyondCompareFilePath, this.PathToExe, this.TimeLimit, this.MemoryLimit));
            }
        }

        /// <summary>
        /// Creates the result tests folder.
        /// </summary>
        private void CreateResultTestsFolder()
        {
            if (!Directory.Exists(this.ResultTestDirectoryPath))
            {
                Directory.CreateDirectory(this.ResultTestDirectoryPath);
            }
        }
    }
}