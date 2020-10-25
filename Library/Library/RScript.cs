using System;
using System.Diagnostics;
using System.IO;

namespace Library
{
    static class RScript
    {
        public static string RunRScript(string rpath, string script)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = rpath,
                    WorkingDirectory = Path.GetDirectoryName(script),
                    Arguments = script,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (Process proc = new Process { StartInfo = info })
                {
                    proc.Start();
                    return proc.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return string.Empty;
        }
    }
}