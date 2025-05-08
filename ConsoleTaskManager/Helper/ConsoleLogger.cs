using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Helper
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine($"[DEBUG] {DateTime.Now}: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        }

        public void LogException(Exception ex)
        {
            Console.WriteLine($"[Exeption] {DateTime.Now}: {ex.Message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"[WARN] {DateTime.Now}: {message}");
        }
    }
}
