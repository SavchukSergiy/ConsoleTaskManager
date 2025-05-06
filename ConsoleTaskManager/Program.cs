using ConsoleTaskManager;

TaskManager taskManager = new TaskManager();
string filePath = "tasks.txt";

taskManager.LoadTasksFromFile(filePath);

while (true)
{
    Console.WriteLine("\nChoose an action:");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Show Tasks");
    Console.WriteLine("3. Mark Task as Completed");
    Console.WriteLine("4. Remove Task");
    Console.WriteLine("5. Save Tasks to File");
    Console.WriteLine("6. Load Tasks from File");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            taskManager.AddTask(description);
            break;
        case "2":
            taskManager.ShowTasks();
            break;
        case "3":
            Console.Write("Enter task number to mark as completed: ");
            int completedTaskNumber = int.Parse(Console.ReadLine());
            taskManager.MarkTaskAsCompleted(completedTaskNumber);
            break;
        case "4":
            Console.Write("Enter task number to remove: ");
            int removeTaskNumber = int.Parse(Console.ReadLine());
            taskManager.RemoveTask(removeTaskNumber);
            break;
        case "5":
            taskManager.SaveTasksToFile(filePath);
            break;
        case "6":
            taskManager.LoadTasksFromFile(filePath);
            break;
        case "7":
            return;
        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}