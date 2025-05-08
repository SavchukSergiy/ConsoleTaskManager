using ConsoleTaskManager.Models;

namespace ConsoleTaskManager.Repository
{
    public interface ITaskRepository
    {
        void AddTask(ClientTask task);
        ClientTask? RemoveTask(int taskId);
        void UpdateTask(int taskId);
        List<ClientTask> GetAllTasks();
        ClientTask? GetTaskById(int taskId);
        void SaveTasksToFile(string filePath);
        bool LoadTasksFromFile(string filePath);
        //void UpdateTask(int taskId, string newTaskName, DateTime newDueDate);
        //Task GetTaskById(int taskId);
    }
}
