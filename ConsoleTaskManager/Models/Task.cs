using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Models
{
    public class Task : Task
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string description)
        {
            Description = description;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public string ShowTask()
        {
            return $"{Description} - {(IsCompleted ? "Completed" : "Not Completed")}";
        }
    }
}
