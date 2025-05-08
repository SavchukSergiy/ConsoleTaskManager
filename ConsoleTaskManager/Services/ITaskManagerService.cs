using ConsoleTaskManager.Models;

namespace ConsoleTaskManager.Services
{
    public interface ITaskManagerService
    {
        void AddTask(string description);
        List<ClientTask> GetAllTasks();
        void MarkTaskAsCompleted(int taskId);
        void RemoveTask(int taskId);
        void SaveTasksToFile(string filePath);
        void LoadTasksFromFile(string filePath);
        //void UpdateTask(int taskId, string newTaskName, DateTime newDueDate);
        //Task GetTaskById(int taskId);
    }
}
