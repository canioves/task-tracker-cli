using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Interfaces
{
    public interface IRepository
    {
        public AppTask GetTaskFromRepository(int taskId);
        public List<AppTask> GetAllTasksFromRepository();
        public void AddTaskToRepository(string description);
        public void UpdateExistingTaskInReposiroty(int taskId, string newDescription);
        public void DeleteExistingTaskFromRepository(int taskId);
    }
}
