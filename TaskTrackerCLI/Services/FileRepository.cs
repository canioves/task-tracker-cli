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
            string combinePath = Path.Combine(@"..\..\..", repositoryPath);
            actualPath = Path.GetFullPath(combinePath);
            CreateFileIfNotExist();
        }

        private void CreateFileIfNotExist()
        {
            if (!File.Exists(actualPath))
            {
                FileStream f = File.Create(actualPath);
                f.Close();
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
            return string.IsNullOrEmpty(json)
                ? new List<AppTask>()
                : JsonMapper.JsonToAllTasks(json);
        }

        public AppTask GetTaskFromRepository(int taskId)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            return tasks.Find(x => x.Id == taskId);
        }

        public void AddTaskToRepository(string description)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            int newID = 1;
            if (tasks.Count > 0)
            {
                AppTask lastTask = tasks.Last();
                newID = lastTask.Id + 1;
            }
            AppTask newTask = new AppTask(newID, description);
            tasks.Add(newTask);
            WriteToRepository(tasks);
        }

        public void UpdateExistingTaskInReposiroty(int taskId, string newDescription)
        {
            List<AppTask> tasks = GetAllTasksFromRepository();
            AppTask task = tasks.Find(x => x.Id == taskId);
            task.Description = newDescription;
            task.UpdatedAt = DateTime.UtcNow;
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
