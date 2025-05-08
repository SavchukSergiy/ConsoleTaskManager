namespace ConsoleTaskManager.Models
{
    public class ClientTask : IClientTask
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ClientTask(string description)
        {
            Description = description;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public string ShowTask()
        {
            return $"{Description} - {(IsCompleted ? "Completed" : "Not Completed")}";
        }
    }
}
