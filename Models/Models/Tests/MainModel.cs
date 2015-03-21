using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Models.Logic;

namespace Models.Models.Tests
{
    public class MainModel
    {
        private List<TestsResultsModel> allTests;
        private Configuration configuration;

        public string TaskName { get; set; }

        public string SourceCodePath { get; set; }

        public string TestsResultsFolderPath { get; set; }

        public string ExpectedOutputFolder { get; set; }

        public List<TestsResultsModel> AllTests
        {
            get
            {
                if (allTests == null)
                {
                    allTests = new List<TestsResultsModel>();
                }
                return allTests;
            }
        }

        public MainModel()
        {
            configuration = new Configuration();
        }

        public void RunAllTests()
        {
            TestsResultsModel testResults = new TestsResultsModel(this.ExpectedOutputFolder, this.TestsResultsFolderPath, this.SourceCodePath, this.TaskName, configuration);
			AllTests.Insert(0, testResults);
            testResults.RunAllTests();
        }
    }
}
