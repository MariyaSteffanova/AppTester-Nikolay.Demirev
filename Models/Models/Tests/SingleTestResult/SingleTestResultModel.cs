using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Models.Logic;
using System.Diagnostics;
using System.Threading;

namespace Models.Models.Tests.SingleTestResult
{
	public enum TestState
	{
		Passed,
		NotPassed,
		TimeLimit,
		Error,
		MemoryLimit,
		ToBeTested,
		BuildError,
	}

	delegate void IOHandlerDelegate(object exeProcess);

	public class SingleTestResultModel
	{
		private const string StartOfExceptionMessage = "Unhandled Exception: ";

		/// <summary>
		/// Gets the state of the test.
		/// </summary>
		/// <value>
		/// The state of the test.
		/// </value>
		public TestState TestState { get; private set; }

		/// <summary>
		/// Gets output of the standart error stream of the process
		/// </summary>
		/// <value>
		/// StandartError output
		/// </value>
		public string StandartErrorOutput { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance can compare with expected output.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance can compare with expected output; otherwise, <c>false</c>.
		/// </value>
		public bool CanCompareWithExpectedOutput { get; private set; }

		/// <summary>
		/// Gets the input test file path.
		/// </summary>
		public string InputTestFilePath { get; private set; }

		/// <summary>
		/// Gets the result test file path.
		/// </summary>
		public string ResultTestFilePath { get; private set; }

		/// <summary>
		/// Gets the output test file path.
		/// </summary>
		public string ExpectedOutputTestFilePath { get; private set; }

		/// <summary>
		/// Gets or sets the path to builded source.
		/// </summary>
		/// <value>
		/// The path to builded source.
		/// </value>
		private string PathToBuildedSource { get; set; }

		/// <summary>
		/// Gets or sets the beyond compare file path.
		/// </summary>
		/// <value>
		/// The beyond compare file path.
		/// </value>
		private string BeyondCompareFilePath { get; set; }

		/// <summary>
		/// Gets the used memory in MB.
		/// </summary>
		public float UsedMemoryMB { get; private set; }

		/// <summary>
		/// Gets or sets the memory limit.
		/// </summary>
		/// <value>
		/// The memory limit.
		/// </value>
		private int MemoryLimitInMB
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the used time in ms.
		/// </summary>
		public double UsedTime { get; private set; }

		/// <summary>
		/// Gets the exception message.
		/// </summary>
		public string ExceptionMessage
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is exception.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is exception; otherwise, <c>false</c>.
		/// </value>
		public bool IsException
		{
			get;
			private set;
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
		/// Initializes a new instance of the <see cref="SingleTestResultModel"/> class.
		/// </summary>
		/// <param name="inputTestFilePath">The input test file path.</param>
		/// <param name="resultTestFilePath">The result test file path.</param>
		/// <param name="ExpectedOutputTestFilePath">The output test file path.</param>
		/// <param name="beyondCompareFilePath">The beyond compare file path.</param>
		/// <param name="pathToBuildedSource">The path to builded source.</param>
		/// <param name="timeLimit">The time limit.</param>
		/// <param name="memoryLimit">The memory limit.</param>
		public SingleTestResultModel(string inputTestFilePath, string resultTestFilePath, string ExpectedOutputTestFilePath, string beyondCompareFilePath, string pathToBuildedSource, int timeLimit, int memoryLimit)
		{
			this.InputTestFilePath = inputTestFilePath;
			this.ResultTestFilePath = resultTestFilePath;
			this.ExpectedOutputTestFilePath = ExpectedOutputTestFilePath;
			this.BeyondCompareFilePath = beyondCompareFilePath;
			this.PathToBuildedSource = pathToBuildedSource;
			this.TimeLimit = timeLimit;
			this.MemoryLimitInMB = memoryLimit;

			this.TestState = TestState.ToBeTested;
		}

		/// <summary>
		/// Runs the test.
		/// </summary>
		public void RunTest()
		{
			long peakMemory = 0;
			IOHandlerDelegate IOHandler = HandleIO;

			//TODO - handle exceptions
			ProcessStartInfo processInfo = this.CreateProcessStartInfo();

			using (Process exeProcess = Process.Start(processInfo))
			{
				ParameterizedThreadStart start = new ParameterizedThreadStart(IOHandler);
				Thread IOThread = new Thread(start);
				IOThread.Start(exeProcess);

				//manually blocking the current thread while the process is alive and under the time limit!
				while (!exeProcess.HasExited)// && watch.ElapsedMilliseconds < this.TimeLimit)
				{
					try
					{
						peakMemory = exeProcess.PeakWorkingSet64;
						//stupid to read the value N times per second , but that's the way it's done in the the msdn example : http://msdn.microsoft.com/en-us/library/system.diagnostics.process.workingset64.aspx
						double usedProcessorTime = exeProcess.PrivilegedProcessorTime.TotalMilliseconds;
						this.UsedTime = usedProcessorTime;

						if (usedProcessorTime > TimeLimit)
						{
							TestState = SingleTestResult.TestState.TimeLimit;
							exeProcess.Kill();
							return;
						}
						exeProcess.Refresh();
					}
					catch
					{
						/// this may be caused because process exits right after while (!exeProcess.HasExited)
						/// and when we try to get exeProcess.PeakWorkingSet64 throws exception
					}
				}

				//TODO - find smarter solution 
				while (IOThread.IsAlive)
					;
				IOThread.Abort();

				this.EvaluateTestState(peakMemory, exeProcess.StandardError);
			}
		}

		/// <summary>
		/// Evaluates the state of the current test.
		/// </summary>
		/// <param name="watch">The Stopwatch used to measure the time the test wat running.</param>
		/// <param name="peakMemory">The peak memory of the process.</param>
		private void EvaluateTestState(long peakMemory, StreamReader standartError)
		{
			this.CanCompareWithExpectedOutput = true;

			bool errorOccurred = false;
			if (!standartError.EndOfStream)
			{
				this.StandartErrorOutput = standartError.ReadToEnd();
				errorOccurred = true;

				this.IsException = false;

				int exceptionMessagePosition = this.StandartErrorOutput.IndexOf(StartOfExceptionMessage);
				if (exceptionMessagePosition > 0)
				{
					int exceptionMessageStartPosition = exceptionMessagePosition + StartOfExceptionMessage.Length;
					string messageForParsing = this.StandartErrorOutput.Substring(exceptionMessageStartPosition);

					int exceptionMessageEndPosition = messageForParsing.IndexOf(':');
					this.ExceptionMessage = messageForParsing.Substring(0, exceptionMessageEndPosition);
					this.IsException = true;
				}
			}

			float peakMemoryInMB = peakMemory / 1024f / 1014f; // peakMemory is in bytes
			this.UsedMemoryMB = peakMemoryInMB;

			bool memoryLimitPassed = false;
			if (peakMemoryInMB < this.MemoryLimitInMB)
			{
				memoryLimitPassed = true;
			}

			if (errorOccurred)
			{
				this.TestState = TestState.Error;
			}
			else if (!memoryLimitPassed)
			{
				this.TestState = TestState.MemoryLimit;
			}
			else
			{
				this.CheckTestResults();
			}
		}

		/// <summary>
		/// Handles the process input-output operations. Runs in another thread!
		/// </summary>
		/// <param name="process">The process which will be tested.</param>
		private void HandleIO(object process)
		{
			Process exeProcess = process as Process;

			try
			{
				this.ReadTestInput(exeProcess.StandardInput);
				this.WriteTestOutput(exeProcess.StandardOutput);
			}
			catch
			{
				//TestState = SingleTestResult.TestState.Error;
			}
		}

		/// <summary>
		/// Reads the file with the input for this test.
		/// </summary>
		/// <param name="standartProcessInput">The standart process input.</param>
		private void ReadTestInput(StreamWriter standartProcessInput)
		{
			if (!File.Exists(this.InputTestFilePath))
			{
				throw new FileNotFoundException();
			}

			//TODO exception handling here?
			using (StreamReader reader = new StreamReader(this.InputTestFilePath))
			{
				using (StreamWriter writer = standartProcessInput)
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						writer.WriteLine(line);
					}
				}
			}
		}

		/// <summary>
		/// Writes the output of this test into the default file
		/// </summary>
		/// <param name="standartProcessOutput">The standart process output.</param>
		private void WriteTestOutput(StreamReader standartProcessOutput)
		{
			//TODO exception handling here?
			using (StreamWriter writer = new StreamWriter(this.ResultTestFilePath))
			{
				using (StreamReader reader = standartProcessOutput)
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						writer.WriteLine(line);
					}
				}
			}

		}

		/// <summary>
		/// Creates the process start info using PathToBuildedSource property
		/// </summary>
		/// <returns>ProcessStartInfo</returns>
		/// <exception cref="System.FileNotFoundException">The executable file path is incorrect</exception>
		private ProcessStartInfo CreateProcessStartInfo()
		{
			if (!File.Exists(this.PathToBuildedSource))
			{
				throw new FileNotFoundException();
			}

			ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo();
			process.RedirectStandardInput = true;
			process.RedirectStandardOutput = true;
			process.RedirectStandardError = true;
			process.CreateNoWindow = true;
			process.FileName = this.PathToBuildedSource;
			process.UseShellExecute = false;

			return process;
		}

		/// <summary>
		/// Checks whether the test output is the same as the expected one
		/// </summary>
		private void CheckTestResults()
		{
			//TODO handle exceptions!
			bool areFilesIdentical = FileComparator.Compare(this.ResultTestFilePath, this.ExpectedOutputTestFilePath);

			if (areFilesIdentical)
			{
				this.TestState = TestState.Passed;
			}
			else
			{
				this.TestState = TestState.NotPassed;
			}
		}

		/// <summary>
		/// Compares the with expected output.
		/// </summary>
		public void CompareWithExpectedOutput()
		{
			if (this.CanCompareWithExpectedOutput)
			{
				//TODO handle exceptions!
				FileComparator.DiffWithBeyondCompare(this.ExpectedOutputTestFilePath, this.ResultTestFilePath, this.BeyondCompareFilePath);
			}
		}

		/// <summary>
		/// Sets the state to error.
		/// </summary>
		public void SetStateToBuildError()
		{
			this.TestState = TestState.BuildError;
			this.CanCompareWithExpectedOutput = false;
		}
	}
}
