using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager
{
    public class TaskManager
    {
        private List<Task> tasks;
        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(string description)
        {
            Task newTask = new Task(description);
            tasks.Add(newTask);
        }

        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("List of tasks is empty.");
                return;
            }

            Console.WriteLine("Tasks:");

            foreach (var task in tasks)
            {
                Console.WriteLine(task.ShowTask());
            }
        }
        public void MarkTaskAsCompleted(int taskNumber)
        {
            if (taskNumber < 1 || taskNumber > tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }
            tasks[taskNumber - 1].MarkAsCompleted();
            Console.WriteLine($"Task {taskNumber} marked as completed.");
        }

        public void RemoveTask(int taskNumber)
        {
            if (taskNumber < 1 || taskNumber > tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine($"Task {taskNumber} removed.");
        }

        /// Method to save tasks to a file
        public void SaveTasksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Description}|{task.IsCompleted}");
                }
            }
            Console.WriteLine("Tasks saved to file.");
        }

        /// Method to load tasks from a file
        public void LoadTasksFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            tasks.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        Task task = new Task(parts[0])
                        {
                            IsCompleted = bool.Parse(parts[1])
                        };
                        tasks.Add(task);
                    }
                }
            }
            Console.WriteLine("Tasks loaded from file.");
        }
    }
}
