using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();
        private readonly ILogger _logger;

        public TaskRepository(ILogger logger)
        {
            _logger = logger;
            _logger.LogInfo("TaskRepository initialized.");
        }
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public List<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task? GetTaskById(int taskId)
        {
            if (taskId < 0 || taskId >= _tasks.Count)
            {
                _logger.LogError($"Task with ID {taskId} not found.");
                return null;
            }
            return _tasks[taskId];
        }

        public void LoadTasksFromFile(string filePath)
        {
            _tasks.Clear();
            if (!File.Exists(filePath))
            {
                _logger.LogError($"File not found: {filePath}");
                return;
            }
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int lineNumber = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string description = parts[0];
                            if (bool.TryParse(parts[1], out bool done))
                            {
                                _tasks.Add(new Task(description) { IsCompleted = done });
                            }
                            else
                            {
                                _logger.LogWarning($"Invalid format status in line {lineNumber} by file \"{filePath}\". String missed.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                _logger.LogError($"Error reading file: {filePath}");
            }
        }

        public Task? RemoveTask(int taskId)
        {
            if (taskId < 0 || taskId >= _tasks.Count)
            {
                _logger.LogError($"Task with ID {taskId} not found.");
                return null;
            }
            var removedTask = _tasks[taskId];
            _tasks.RemoveAt(taskId);
            return removedTask;
        }

        public void SaveTasksToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var task in _tasks)
                    {
                        writer.WriteLine($"{task.Description},{task.IsCompleted}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving tasks to file: {ex.Message}");
            }
        }

        public void UpdateTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
