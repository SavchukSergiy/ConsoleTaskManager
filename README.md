# ConsoleTaskManager
Console Task Manager is a console application written in C# for managing a task list. It allows you to add, view, mark as completed, and delete tasks, as well as save them to and load them from a file.

# Functionality
 - Add Task: Adds a new task to the list.

 - View Tasks: Displays a list of all tasks with their status.

 - Mark Task as Completed: Marks the selected task as completed.

 - Delete Task: Deletes the selected task from the list.

 - Save Tasks to File: Saves the current task list to a text file.

 - Load Tasks from File: Loads the task list from a text file.

 - Exit: Closes the program.

# Technologies
 - C#
 - .NET

# Installation
1) Make sure you have the .NET SDK tools installed.
2) Clone Repo (git clone <https://github.com/SavchukSergiy/ConsoleTaskManager.git>)
3) Go to the project directory: (cd ConsoleTaskManager)
4) Restore dependencies: (dotnet restore)
5) Project assembly: (dotnet build)

# Using
1) Go to the build directory (usually bin/Debug/net6.0 or similar)
2) Run the program (dotnet ConsoleTaskManager.exe)
3) Follow these steps to use the app:
  * Enter the appropriate number to select an action.
  * Follow the on-screen instructions.

# Code structure
The project has the following structure:

 * ConsoleTaskManager.csproj: C# project file.
 * Program.cs: Main class containing the application entry point and user interface.
 * Services/: Contains service classes that implement business logic (e.g. TaskManagerService).
 * Repository/: Contains repository classes responsible for data storage (e.g. TaskRepository).
 * Helper/: Contains helper classes (e.g. ConsoleLogger).
 * Model/: Contains data model classes (e.g. Task).
 * Unit Tests project.

# Author 
Savchuk Sergiy

# License
MIT
