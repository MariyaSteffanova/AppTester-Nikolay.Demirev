using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace Models.Logic
{
    public class Configuration
    {
        private const string BeyondCompareFolderKey = "BeyondCompareFolderKey";
        private const string TestsResultsFolderKey = "TestsResultsFolder";
		private const string TestsImputsFolderKey = "TestsImputsFolder";
        private const string HistoryFolderKey = "HistoryFolder";
        private const string TimeLimitKey = "TimeLimitKey";
        private const string MemoryLimitKey = "MemoryLimitKey";
		private const string SourceCodePathKey = "SourceCodePath";
		private const string ExpectedOutputFolderKey = "ExpectedOutputFolder";
		private const int MinTimeLimit = 100; // miliseconds
		private const int MinMemoryLimit = 16; // MB

        public string BeyondCompareFilePath
        {
            get
            {
                string folder = (string)Registry.CurrentUser.GetValue(BeyondCompareFolderKey);

                if (folder == null)
                {
                    folder = Environment.CurrentDirectory;
                }

                return folder;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException();
                }
                else if (!File.Exists(value))
                {
                    throw new ArgumentException("Invalid Path!");
                }

                Registry.CurrentUser.SetValue(BeyondCompareFolderKey, value);
            }
        }

        public string TestsImputsFolderPath
        {
            get
            {
				string folder = (string)Registry.CurrentUser.GetValue(TestsImputsFolderKey);

                if (folder == null)
                {
                    folder = Environment.CurrentDirectory;
                }

                return folder;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException();
                }
                else if (!Directory.Exists(value))
                {
                    throw new ArgumentException("Invalid Path!");
                }

				Registry.CurrentUser.SetValue(TestsImputsFolderKey, value);
            }
        }

		public string TestsResultsFolderPath
		{
			get
			{
				string folder = (string)Registry.CurrentUser.GetValue(TestsResultsFolderKey);

				if (folder == null)
				{
					folder = Environment.CurrentDirectory;
				}

				return folder;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new NullReferenceException();
				}
				else if (!Directory.Exists(value))
				{
					throw new ArgumentException("Invalid Path!");
				}

				Registry.CurrentUser.SetValue(TestsResultsFolderKey, value);
			}
		}

        public string HistoryFolder
        {
            get
            {
                string folder = (string)Registry.CurrentUser.GetValue(HistoryFolderKey);

                if (folder == null)
                {
                    folder = Environment.CurrentDirectory;
                }

                return folder;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException();
                }
                else if (!Directory.Exists(value))
                {
                    throw new ArgumentException("Invalid Path!");
                }

                Registry.CurrentUser.SetValue(HistoryFolderKey, value);
            }
        }

		public string SourceCodePath
		{
			get
			{
				string folder = (string)Registry.CurrentUser.GetValue(SourceCodePathKey);

				if (folder == null)
				{
					folder = Environment.CurrentDirectory;
				}

				return folder;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new NullReferenceException();
				}
				else if (!File.Exists(value))
				{
					throw new ArgumentException("Invalid Path!");
				}

				Registry.CurrentUser.SetValue(SourceCodePathKey, value);
			}
		}

		public string ExpectedOutputFolder
		{
			get
			{
				string folder = (string)Registry.CurrentUser.GetValue(ExpectedOutputFolderKey);

				if (folder == null)
				{
					folder = Environment.CurrentDirectory;
				}

				return folder;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new NullReferenceException();
				}
				else if (!Directory.Exists(value))
				{
					throw new ArgumentException("Invalid Path!");
				}

				Registry.CurrentUser.SetValue(ExpectedOutputFolderKey, value);
			}
		}

        public int TimeLimit
        {
            get
            {
				object value = Registry.CurrentUser.GetValue(TimeLimitKey);

				string timeLimit = null;

				if (value == null)
				{
					timeLimit = MinTimeLimit.ToString(); 
				}
				else
				{
					timeLimit = value.ToString();
				}

				return int.Parse(timeLimit);
            }
            set
            {
				if (value >= MinTimeLimit)
				{
					Registry.CurrentUser.SetValue(TimeLimitKey, value);
				}
            }
        }

        public int MemoryLimit
        {
            get
            {
				object value = Registry.CurrentUser.GetValue(MemoryLimitKey);

				string memoryLimit = null;

				if (value == null)
				{
					memoryLimit = MinMemoryLimit.ToString();
				}
				else
				{
					memoryLimit = value.ToString();
				}

				return int.Parse(memoryLimit);
            }
            set
            {
				if (value >= MinMemoryLimit)
				{
					Registry.CurrentUser.SetValue(MemoryLimitKey, value);
				}
            }
        }
    }
}
