using System.Diagnostics;

namespace Tools
{
    class ExcuteScript
    {
        public static string Common(string path)
        {
            using Process process = new();
            process.StartInfo.WorkingDirectory = "./";
            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }

        public static void Void(string path)
        {
            using Process process = new();
            process.StartInfo.WorkingDirectory = "./";
            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
        }
    }
}
