using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Models.Models.Tests.SingleTestResult
{
    public class SingleTestResultViewModel : ViewModelBase
    {
        private SingleTestResultModel model;

        RelayCommand compareWithExpectedOutput;

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
