using System.IO;
using System.Text;

namespace Tools
{
    public class FileLogger
    {
        private const string logsDir = "./logs";

        /// <summary>
        /// 因为目录是临时创建的 所以不能在写入日志时用新的文件夹
        /// </summary>
        public FileLogger()
        {
            Directory.CreateDirectory(logsDir);
        }

        public void LogLine(string filePath, string type, string[] msgs)
        {
            StreamWriter sw = new StreamWriter($"{logsDir}/{filePath}", true, Encoding.UTF8);
            sw.WriteLine($"<{type}>");
            foreach (var msg in msgs)
            {
                sw.WriteLine(msg);
            }
            sw.Close();
        }

        public void LogLine(string filePath, string type, string msg)
        {
            StreamWriter sw = new StreamWriter($"{logsDir}/{filePath}", true, Encoding.UTF8);
            sw.WriteLine($"<{type}>");
            sw.WriteLine(msg);
            sw.Close();
        }
    }
}
