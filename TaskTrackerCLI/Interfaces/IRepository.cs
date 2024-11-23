using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Interfaces
{
    public interface IRepository
    {
        public AppTask GetTaskFromRepository(int taskId);
        public void SaveTaskToRepository(AppTask task);        
    }
}