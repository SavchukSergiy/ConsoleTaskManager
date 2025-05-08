namespace ConsoleTaskManager.Models
{
    public interface IClientTask
    {
        string Description { get; set; }
        bool IsCompleted { get; set; }
        void MarkAsCompleted();
        string ShowTask();
    }
}
