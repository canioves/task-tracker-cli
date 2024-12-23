using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    public class AppTaskService
    {
        private IRepository _repository;

        public AppTaskService(IRepository repository)
        {
            _repository = repository;
        }

        public AppTask GetTask(int id) => _repository.GetTaskFromRepository(id);

        public void AddTask(string description) => _repository.AddTaskToRepository(description);

        public void UpdateTask(int id, string newDescription) =>
            _repository.UpdateExistingTaskInReposiroty(id, newDescription);

        public void DeleteTask(int id) => _repository.DeleteExistingTaskFromRepository(id);
    }
}
