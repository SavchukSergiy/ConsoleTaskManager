﻿using Moq;
using ConsoleTaskManager.Models;
using ConsoleTaskManager.Services;
using ConsoleTaskManager.Repository;
using ConsoleTaskManager.Helper;

namespace ConsoleTaskManager.Tests.Services
{
    public class TaskManagerServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IConsoleLogger> _loggerMock;
        private readonly TaskManagerService _taskManagerService;

        public TaskManagerServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _loggerMock = new Mock<IConsoleLogger>();
            _taskManagerService = new TaskManagerService(_taskRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void AddTask_ShouldAddTaskAndLogInfo()
        {
            // Arrange
            string description = "Test Task";

            // Act
            _taskManagerService.AddTask(description);

            // Assert
            _taskRepositoryMock.Verify(tr => tr.AddTask(It.IsAny<ClientTask>()), Times.Once);
            _loggerMock.Verify(l => l.LogInfo(It.Is<string>(s => s.Contains("Task added:"))), Times.Once);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var tasks = new List<ClientTask>
            {
                new ClientTask("Task 1"),
                new ClientTask("Task 2")
            };
            _taskRepositoryMock.Setup(tr => tr.GetAllTasks()).Returns(tasks);

            // Act
            var result = _taskManagerService.GetAllTasks();

            // Assert
            Assert.Equal(tasks, result);
        }

        [Fact]
        public void MarkTaskAsCompleted_ShouldMarkTaskAndLogInfo()
        {
            // Arrange
            int taskId = 1;
            var task = new ClientTask("Test Task");
            _taskRepositoryMock.Setup(tr => tr.GetTaskById(taskId)).Returns(task);

            // Act
            _taskManagerService.MarkTaskAsCompleted(taskId);

            // Assert
            _taskRepositoryMock.Verify(tr => tr.UpdateTask(task), Times.Once);
            _loggerMock.Verify(l => l.LogInfo(It.Is<string>(s => s.Contains("Task marked as completed:"))), Times.Once);
        }

        [Fact]
        public void RemoveTask_ShouldRemoveTaskAndLogInfo()
        {
            // Arrange
            int taskId = 1;
            var task = new ClientTask("Test Task");
            _taskRepositoryMock.Setup(tr => tr.RemoveTask(taskId)).Returns(task);

            // Act
            _taskManagerService.RemoveTask(taskId);

            // Assert
            _taskRepositoryMock.Verify(tr => tr.RemoveTask(taskId), Times.Once);
            _loggerMock.Verify(l => l.LogInfo(It.Is<string>(s => s.Contains("Task removed:"))), Times.Once);
        }

        [Fact]
        public void SaveTasksToFile_ShouldSaveTasksAndLogInfo()
        {
            // Arrange
            string filePath = "tasks.txt";

            // Act
            _taskManagerService.SaveTasksToFile(filePath);

            // Assert
            _taskRepositoryMock.Verify(tr => tr.SaveTasksToFile(filePath), Times.Once);
            _loggerMock.Verify(l => l.LogInfo(It.Is<string>(s => s.Contains("Tasks saved to file:"))), Times.Once);
        }

        [Fact]
        public void LoadTasksFromFile_ShouldLoadTasksAndLogInfo()
        {
            // Arrange
            string filePath = "newTask.txt";

            // Act
            _taskManagerService.LoadTasksFromFile(filePath);

            // Assert
            _taskRepositoryMock.Verify(tr => tr.LoadTasksFromFile(filePath), Times.Once);
        }
    }
}
