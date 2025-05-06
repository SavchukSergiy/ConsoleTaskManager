using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Models;
using ConsoleTaskManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Services
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;

        public TaskManagerService(ITaskRepository taskRepository, ILogger logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
            _logger.LogInfo("TaskManagerService initialized.");
        }
        public void AddTask(string description)
        {
            var newTask = new Task(description);
            _taskRepository.AddTask(newTask);
            _logger.LogInfo($"Task added: {description}");
        }

        public List<Task> GetAllTasks()
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
            var removedTask = _taskRepository.RemoveTask(taskId);
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
            try
            {
                _taskRepository.LoadTasksFromFile(filePath);
                _logger.LogInfo($"Tasks loaded from file: {filePath}");
            }
            catch (Exception)
            {
                _logger.LogError($"Error loading tasks from file: {filePath}");
            }
        }
    }
}
