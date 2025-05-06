using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTaskManager.Models;

namespace ConsoleTaskManager.Services
{
    public interface ITaskManagerService
    {
        void AddTask(string description);
        List<Task> GetAllTasks();
        void MarkTaskAsCompleted(int taskId);
        void RemoveTask(int taskId);
        void SaveTasksToFile(string filePath);
        void LoadTasksFromFile(string filePath);
        //void UpdateTask(int taskId, string newTaskName, DateTime newDueDate);
        //Task GetTaskById(int taskId);
    }
}
