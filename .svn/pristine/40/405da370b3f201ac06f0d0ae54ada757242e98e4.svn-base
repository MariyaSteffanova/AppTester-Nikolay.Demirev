using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Models.Logic
{
    public static class FileComparator
    {
        /// <summary>
        /// Compares two files byte by byte
        /// </summary>
        /// <param name="file1Path">The file 1 path.</param>
        /// <param name="file2Path">The file 2 path.</param>
        /// <returns>Returns TRUE if files are identical!</returns>
        /// <exception cref="System.ArgumentException">Both paths point to the same file</exception>
        /// <exception cref="System.FileNotFoundException">One or both of the files don't exist</exception>
        static public bool Compare(string file1Path, string file2Path)
        {
            if( !File.Exists(file1Path) || !File.Exists(file2Path)  )
            {
                throw new FileNotFoundException();
            }

            if (file1Path == file2Path)
            {
                throw new ArgumentException("File paths are the same!");
            }

            using (FileStream stream1 = new FileStream(file1Path, FileMode.Open))
            {
                using (FileStream stream2 = new FileStream(file2Path, FileMode.Open))
                {
                    Int32 file1, file2;

                    if (stream1.Length != stream2.Length)
                    {
                        return false;
                    }

                    do
                    {
                        file1 = stream1.ReadByte();
                        file2 = stream2.ReadByte();
                    }
                    while ((file1 == file2) && (file1 != -1));

                    return file1 == file2;
                }
            }
        }


        /// <summary>
        /// Shows the difference in two text files using an external file comparator
        /// </summary>
        /// <param name="file1Path">The file 1 path.</param>
        /// <param name="file2Path">The file 2 path.</param>
        /// <param name="beyondComparePath">The path to the external file comparator executable file.</param>
        /// <returns>Returns TRUE if files are identical!</returns>
        /// <exception cref="System.ArgumentException">Both paths point to the same file</exception>
        /// <exception cref="System.FileNotFoundException">One or both of the text files don't exist or the path to the executable file is incorrect</exception>
        static public void DiffWithBeyondCompare(string file1Path, string file2Path, string beyondComparePath)
        {
            if (!File.Exists(beyondComparePath))
            {
                throw new FileNotFoundException("Can't find File Comparator executable file!");
            }

            if (!File.Exists(file1Path) || !File.Exists(file2Path))
            {
                throw new FileNotFoundException();
            }

            if (file1Path == file2Path)
            {
                throw new ArgumentException("File paths are the same!");
            }

            ProcessStartInfo consoleApp = new System.Diagnostics.ProcessStartInfo();
            consoleApp.RedirectStandardInput = true;
            consoleApp.RedirectStandardOutput = true;
            consoleApp.UseShellExecute = false;
            consoleApp.Arguments = " \"" + file1Path + "\" \"" + file2Path;

            consoleApp.FileName = beyondComparePath;

            Process process = Process.Start(consoleApp);
        }
    }
}
