using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace Models.Logic
{
    class Compiler
    {
        /// <summary>
        /// Gets or sets the path to source code.
        /// </summary>
        public string SourceCodePath { get; private set; }

        /// <summary>
        /// Gets or sets the path to source code.
        /// </summary>
        public string ExeFilePath { get; private set; }

        /// <summary>
        /// Gets the list of the compiler errors. Null before compilation!
        /// </summary>
        public CompilerErrorCollection ErrorList { get; private set; }

        private CompilerParameters CompilerParameters { get; set; }

        private CodeDomProvider Provider { get; set; }

        private readonly string[] systemReferences = new string[] { 
            "Microsoft.CSharp.dll",
            "System.dll",
            "System.Core.dll", 
            "System.Data.DLL",         
            "System.Data.DataSetExtensions.dll",
            "System.Data.Linq.dll",     
            "System.Xml.dll",
            "System.Xml.Linq.dll",
			"System.Numerics.dll",
            "PowerCollections.dll",
        };

        public Compiler(string sourceCodePath, string exeFilePath)
        {
            this.SourceCodePath = sourceCodePath;
            this.ExeFilePath = exeFilePath;
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (!File.Exists(Path.Combine(Path.GetDirectoryName(exeFilePath), "PowerCollections.dll")))
			{
				File.Copy("PowerCollections.dll", Path.Combine(Path.GetDirectoryName(exeFilePath), "PowerCollections.dll"));
			}

            this.Provider = CodeDomProvider.CreateProvider("CSharp");

            this.InitCompilerParameters();
            this.AddReferences();
        }

        /// <summary>
        /// Compiles the given source code file
        /// </summary>
        /// <returns></returns>
        public bool Compile()
        {
            bool compileOk = false;

            // Invoke compilation of the source file.
            CompilerResults cr = this.Provider.CompileAssemblyFromFile(this.CompilerParameters, this.SourceCodePath);

            this.ErrorList = cr.Errors;

            if (cr.Errors.Count == 0)
            {
                compileOk = true;
            }

            return compileOk;
        }

        private void InitCompilerParameters()
        {
            this.CompilerParameters = new CompilerParameters();

            // Generate an executable instead of 
            // a class library.
            this.CompilerParameters.GenerateExecutable = true;

            // Specify the assembly file name to generate.
            this.CompilerParameters.OutputAssembly = this.ExeFilePath;

            // Save the assembly as a physical file.
            this.CompilerParameters.GenerateInMemory = false;

            // Set whether to treat all warnings as errors.
            this.CompilerParameters.TreatWarningsAsErrors = false;
        }

        /// <summary>
        /// Adds references.
        /// </summary>
        private void AddReferences()
        {
            this.CompilerParameters.ReferencedAssemblies.AddRange(this.systemReferences);
        }
    }
}
