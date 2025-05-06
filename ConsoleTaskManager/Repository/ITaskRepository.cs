using ConsoleTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager.Repository
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        Task? RemoveTask(int taskId);
        void UpdateTask(int taskId);
        List<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        void SaveTasksToFile(string filePath);
        void LoadTasksFromFile(string filePath);
        //void UpdateTask(int taskId, string newTaskName, DateTime newDueDate);
        //Task GetTaskById(int taskId);
    }
}
