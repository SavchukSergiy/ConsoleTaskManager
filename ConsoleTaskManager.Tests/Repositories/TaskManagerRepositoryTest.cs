using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ConsoleTaskManager.Helper;
using ConsoleTaskManager.Models;
using ConsoleTaskManager.Repository;

namespace ConsoleTaskManager.Tests.Repositories
{
    public class TaskManagerRepositoryTest
    {
        private readonly Mock<IConsoleLogger> _loggerMock;
        private readonly TaskRepository _taskRepository;

        public TaskManagerRepositoryTest()
        {
            _loggerMock = new Mock<IConsoleLogger>();
            _taskRepository = new TaskRepository(_loggerMock.Object);
        }

        [Fact]
        public void AddTask_ShouldAddTask()
        {
            // Arrange
            var task = new ClientTask("Test Task");

            // Act
            _taskRepository.AddTask(task);

            // Assert
            var tasks = _taskRepository.GetAllTasks();
            Assert.Single(tasks);
            Assert.Equal(task, tasks[0]);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new ClientTask("Task 1");
            var task2 = new ClientTask("Task 2");
            _taskRepository.AddTask(task1);
            _taskRepository.AddTask(task2);

            // Act
            var tasks = _taskRepository.GetAllTasks();

            // Assert
            Assert.Equal(2, tasks.Count);
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
        }

        [Fact]
        public void GetTaskById_ShouldReturnTask_WhenIdIsValid()
        {
            // Arrange
            var task = new ClientTask("Test Task");
            _taskRepository.AddTask(task);

            // Act
            var result = _taskRepository.GetTaskById(0);

            // Assert
            Assert.Equal(task, result);
        }

        [Fact]
       public void RemoveTask_ShouldRemoveTask_WhenIdIsValid()
        {
            // Arrange
            var task = new ClientTask("Test Task");
            _taskRepository.AddTask(task);

            // Act
            var removedTask = _taskRepository.RemoveTask(0);

            // Assert
            Assert.Equal(task, removedTask);
            Assert.Empty(_taskRepository.GetAllTasks());
        }

        [Fact]
        public void LoadTasksFromFile_ShouldReturnFalse_WhenFileDoesNotExist()
        {
            // Arrange
            string filePath = "non_existent_file.txt";

            // Act
            bool result = _taskRepository.LoadTasksFromFile(filePath);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateTask_ShouldUpdateTask_WhenIdIsValid()
        {
            // Arrange
            var task = new ClientTask("Test Task");
            _taskRepository.AddTask(task);
            var updatedTask = _taskRepository.GetTaskById(0);
            updatedTask.IsCompleted = true;

            // Act
            _taskRepository.UpdateTask(updatedTask);

            // Assert
            var tasks = _taskRepository.GetAllTasks();
            Assert.Single(tasks);
            Assert.Equal(updatedTask, tasks[0]);
        }
    }
}
