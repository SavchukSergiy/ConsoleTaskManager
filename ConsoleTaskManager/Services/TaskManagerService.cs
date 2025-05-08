using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Models;
using ConsoleTaskManager.Repository;

namespace ConsoleTaskManager.Services
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IConsoleLogger _logger;

        public TaskManagerService(ITaskRepository taskRepository, IConsoleLogger logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
            _logger.LogInfo("TaskManagerService initialized.");
        }
        public void AddTask(string description)
        {
            var newTask = new ClientTask(description);
            _taskRepository.AddTask(newTask);
            _logger.LogInfo($"Task added: {description}");
        }

        public List<ClientTask> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task != null)
            {
                task.MarkAsCompleted();
                _taskRepository.UpdateTask(taskId);
                _logger.LogInfo($"Task marked as completed: {taskId}");
            }
            else
            {
                _logger.LogWarning($"Task not found: {taskId}");
            }
        }

        public void RemoveTask(int taskId)
        {
            ClientTask removedTask = _taskRepository.RemoveTask(taskId);
            if (removedTask != null)
            {
                _logger.LogInfo($"Task removed: {taskId}");
            }
            else
            {
                _logger.LogWarning($"Task not found: {taskId}");
            }
        }

        public void SaveTasksToFile(string filePath)
        {
            try
            {
                _taskRepository.SaveTasksToFile(filePath);
                _logger.LogInfo($"Tasks saved to file: {filePath}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving tasks to file: {ex.Message}");
            }
        }

        public void LoadTasksFromFile(string filePath)
        {
             var result = _taskRepository.LoadTasksFromFile(filePath);
                if (!result)
                {
                    _logger.LogError($"Failed to load tasks from file: {filePath}");
                    return;
                }
                _logger.LogInfo($"Tasks loaded from file: {filePath}");
        }
    }
}
