using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;
using TaskTrackerCLI.Utilities;

namespace TaskTrackerCLI.Services
{
    public class Repository : IRepository
    {
        private readonly string _repositoryPath;

        public Repository(string repositoryPath)
        {
            _repositoryPath = repositoryPath;
        }

        public AppTask GetTaskFromRepository(int taskId)
        {
            throw new NotImplementedException();
        }

        public void SaveTaskToRepository(AppTask task)
        {
            throw new NotImplementedException();
        }
    }
}