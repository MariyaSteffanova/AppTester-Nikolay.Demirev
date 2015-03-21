using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Logic;

namespace Models.Models.Options
{
	public class OptionsModel
	{
		Configuration config;

		public string HistoryFolder
		{
			get
			{
				return config.HistoryFolder;
			}
			set
			{
				config.HistoryFolder = value;
			}
		}

		public string TestsResultsFolder
		{
			get
			{
				return config.TestsImputsFolderPath;
			}
			set
			{
				config.TestsImputsFolderPath = value;
			}
		}

		public string BeyondCompareFilePath
		{
			get
			{
				return config.BeyondCompareFilePath;
			}
			set
			{
				config.BeyondCompareFilePath = value;
			}
		}

		public int TimeLimit
		{
			get
			{
				return config.TimeLimit;
			}
			set
			{
				config.TimeLimit = value;
			}
		}

		public int MemoryLimit
		{
			get
			{
				return config.MemoryLimit;
			}
			set
			{
				config.MemoryLimit = value;
			}
		}

		public OptionsModel()
		{
			config = new Configuration();
		}
	}
}
