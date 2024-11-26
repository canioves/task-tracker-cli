using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;
using TaskTrackerCLI.Utilities;

namespace TaskTrackerCLI.Services
{
    public class FileRepository : IRepository
    {
        private string actualPath;

        public FileRepository(string repositoryPath)
        {
            string dbFileName = "taskDB.json";
            string combinePath = Path.Combine(@"..\..\..\..", repositoryPath, dbFileName);
            actualPath = Path.GetFullPath(combinePath);
            CreateFileIfNotExist();
        }

        private void CreateFileIfNotExist()
        {
            if (!File.Exists(actualPath))
            {
                File.Create(actualPath);
            }
        }

        private string ReadFromRepository() => File.ReadAllText(actualPath);

        private void WriteToRepository(List<AppTask> tasks)
        {
            string json = JsonMapper.AllTasksToJson(tasks);
            File.WriteAllText(actualPath, json);
        }

        public List<AppTask> GetAllTasksFromRepository()
        {
            string json = ReadFromRepository();
            return JsonMapper.JsonToAllTasks(json);
        }

        public AppTask GetTaskFromRepository(int taskId)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            return tasks.Find(x => x.Id == taskId);
        }

        public void AddTaskToRepository(AppTask task)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            if (tasks.Exists(x => x.Equals(task)))
            {
                throw new ArgumentException("This task already exists!");
            }
            tasks.Add(task);
            WriteToRepository(tasks);
        }

        public void UpdateExistingTaskInReposiroty(int taskId, string newDescription)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            AppTask task = tasks.Find(x => x.Id == taskId);
            task.Description = newDescription;
            WriteToRepository(tasks);
        }

        public void DeleteExistingTaskFromRepository(int taskId)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            AppTask task = tasks.Find(x => x.Id == taskId);
            tasks.Remove(task);
            WriteToRepository(tasks);
        }
    }
}
