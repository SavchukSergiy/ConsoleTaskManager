using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Repository;
using ConsoleTaskManager.Services;

public class Program
{
    private static ITaskManagerService? _taskManagerService;
    private static string _filePath = "newTask.txt";

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var logger = new ConsoleLogger();
        var taskRepository = new TaskRepository(logger);
        _taskManagerService = new TaskManagerService(taskRepository, logger);

        _taskManagerService.LoadTasksFromFile(_filePath);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║        TASK MANAGER        ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.WriteLine("1.  Add Task");
            Console.WriteLine("2.  View All Tasks");
            Console.WriteLine("3.  Mark Task as Completed");
            Console.WriteLine("4.  Remove Task");
            Console.WriteLine("5.  Save Tasks to File");
            Console.WriteLine("6.  Load Tasks from File");
            Console.WriteLine("7.  Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write(" Enter task description: ");
                    var description = Console.ReadLine();
                    _taskManagerService.AddTask(description);
                    Console.WriteLine(" Task added successfully!");
                    break;

                case "2":
                    var tasks = _taskManagerService.GetAllTasks();
                    if (!tasks.Any())
                    {
                        Console.WriteLine(" No tasks found.");
                    }
                    else
                    {
                        Console.WriteLine(" TASK LIST:");
                        Console.WriteLine("-------------------------------------------");
                        foreach (var task in tasks)
                        {
                            var status = task.IsCompleted ? " Completed" : " Not Completed";
                            Console.WriteLine($"[{task.Description} - {status}");
                        }
                        Console.WriteLine("-------------------------------------------");
                    }
                    break;

                case "3":
                    Console.Write(" Enter task ID to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int taskIdToComplete))
                    {
                        _taskManagerService.MarkTaskAsCompleted(taskIdToComplete);
                        Console.WriteLine(" Task marked as completed.");
                    }
                    else
                    {
                        Console.WriteLine(" Invalid task ID.");
                    }
                    break;

                case "4":
                    Console.Write(" Enter task ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int taskIdToRemove))
                    {
                        _taskManagerService.RemoveTask(taskIdToRemove);
                        Console.WriteLine(" Task removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine(" Invalid task ID.");
                    }
                    break;

                case "5":
                    _taskManagerService.SaveTasksToFile(_filePath);
                    Console.WriteLine(" Tasks saved successfully.");
                    break;

                case "6":
                    _taskManagerService.LoadTasksFromFile(_filePath);
                    Console.WriteLine(" Tasks loaded from file.");
                    break;

                case "7":
                    Console.WriteLine(" Exiting Task Manager...");
                    return;

                default:
                    Console.WriteLine(" Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
