using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Repository;
using ConsoleTaskManager.Services;
using System.Runtime.CompilerServices;

public class Program
{
    private static ITaskManagerService _taskManagerService;
    private static string _filePath = "newTask.txt";
    public static async Task Main(string[] args)
    {
        var logger = new ConsoleLogger();
        var taskRepository = new TaskRepository(logger);
        _taskManagerService = new TaskManagerService(taskRepository, logger);

        _taskManagerService.LoadTasksFromFile(_filePath);

        while (true)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Save Tasks to File");
            Console.WriteLine("6. Load Tasks from File");
            Console.WriteLine("7. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    var description = Console.ReadLine();
                    _taskManagerService.AddTask(description);
                    break;
                case "2":
                    var tasks = _taskManagerService.GetAllTasks();
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task);
                    }
                    break;
                case "3":
                    Console.Write("Enter task ID to mark as completed: ");
                    var taskIdToComplete = int.Parse(Console.ReadLine());
                    _taskManagerService.MarkTaskAsCompleted(taskIdToComplete);
                    break;
                case "4":
                    Console.Write("Enter task ID to remove: ");
                    var taskIdToRemove = int.Parse(Console.ReadLine());
                    _taskManagerService.RemoveTask(taskIdToRemove);
                    break;
                case "5":
                    _taskManagerService.SaveTasksToFile(_filePath);
                    break;
                case "6":
                    _taskManagerService.LoadTasksFromFile(_filePath);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}