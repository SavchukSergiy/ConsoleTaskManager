using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Models;

namespace ConsoleTaskManager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<ClientTask> _tasks = new List<ClientTask>();
        private readonly IConsoleLogger _logger;

        public TaskRepository(IConsoleLogger logger)
        {
            _logger = logger;
            _logger.LogInfo("TaskRepository initialized.");
        }
        public void AddTask(ClientTask task)
        {
            _tasks.Add(task);
        }

        public List<ClientTask> GetAllTasks()
        {
            return _tasks;
        }

        public ClientTask? GetTaskById(int taskId)
        {
            if (taskId < 0 || taskId >= _tasks.Count)
            {
                _logger.LogError($"Task with ID {taskId} not found.");
                return null;
            }
            return _tasks[taskId];
        }

        public ClientTask? RemoveTask(int taskId)
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

        public bool LoadTasksFromFile(string filePath)
        {
            _tasks.Clear();
            if (!File.Exists(filePath))
            {
                _logger.LogError($"File not found: {filePath}");
                return false;
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
                            if (bool.TryParse(parts[1], out bool completed))
                            {
                                _tasks.Add(new ClientTask(description) { IsCompleted = completed });
                            }
                            else
                            {
                                _logger.LogWarning($"Invalid format status in line {lineNumber} by file \"{filePath}\". String missed.");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                _logger.LogError($"Error reading file: {filePath}");
                return false;
            }
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

        public void UpdateTask(ClientTask task)
        {
            var clientTask = _tasks.FirstOrDefault(t => t.Description == task.Description);

            if (clientTask != null)
            {
                clientTask.MarkAsCompleted();
            }
        }
    }
}
