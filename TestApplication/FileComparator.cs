using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestApplication
{
    static class FileComparator
    {
        public static string BeyondComparePath = @"C:\Program Files\Beyond Compare 3\BCompare.exe";

        static public bool Compare(string file1Path, string file2Path)
        {
            Int32 file1, file2;

            if (file1Path == file2Path)
            {
                throw new ArgumentException("File paths are the same!");
            }

            using (FileStream stream1 = new FileStream(file1Path, FileMode.Open))
            {
                using (FileStream stream2 = new FileStream(file2Path, FileMode.Open))
                {
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

        static public void DiffWithBeyondCompare(string file1Path, string file2Path)
        {
            ProcessStartInfo consoleApp = new System.Diagnostics.ProcessStartInfo();
            consoleApp.RedirectStandardInput = true;
            consoleApp.RedirectStandardOutput = true;
            consoleApp.UseShellExecute = false;
            consoleApp.Arguments = " " + file1Path + " " + file2Path;

            consoleApp.FileName = FileComparator.BeyondComparePath;

            Process process = Process.Start(consoleApp);
        }
    }
}
