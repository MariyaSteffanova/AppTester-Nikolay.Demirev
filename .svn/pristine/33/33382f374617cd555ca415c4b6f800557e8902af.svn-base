using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Models.Models.Tests.SingleTestResult;

namespace Models.Models.Tests
{
    public class TestsResultsViewModel : ViewModelBase
    {
        private TestsResultsModel model;
        private ObservableCollection<SingleTestResultViewModel> testsResults;

        /// <summary>
        /// Gets a value indicating whether all tests are passed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is all tests passed; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllTestsPassed
        {
            get { return model.IsAllTestsPassed; }
        }

        /// <summary>
        /// Gets the time stamp.
        /// </summary>
        public string TimeStamp 
        {
            get { return string.Format("{0}-{1}-{2} {3}:{4}:{5}", model.TimeStamp.Day, model.TimeStamp.Month, model.TimeStamp.Year, model.TimeStamp.Hour, model.TimeStamp.Minute, model.TimeStamp.Second); }
        }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string TaskName
        {
            get
            {
                return model.TaskName;
            }
        }

        /// <summary>
        /// Gets the tests results.
        /// </summary>
        public ObservableCollection<SingleTestResultViewModel> TestsResults 
        {
            get 
            {
                if (testsResults == null)
                {
                    testsResults = new ObservableCollection<SingleTestResultViewModel>();
                    foreach (SingleTestResultModel testResultModel in model.TestsResults)
                    {
                        testsResults.Add(new SingleTestResultViewModel(testResultModel));
                    }
                }
                return testsResults;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsResultsViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public TestsResultsViewModel(TestsResultsModel model)
        {
            this.model = model;
        }
    }
}
