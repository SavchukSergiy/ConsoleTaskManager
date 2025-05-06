using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Models
{
    public interface Task
    {
        string Description { get; set; }
        bool IsCompleted { get; set; }
        void MarkAsCompleted();
        string ShowTask();
    }
}
