using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Helper
{
    public interface IConsoleLogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);
        void LogException(Exception ex);
    }
}
