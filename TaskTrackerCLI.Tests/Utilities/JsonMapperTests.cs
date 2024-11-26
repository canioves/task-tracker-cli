using TaskTrackerCLI.Models;
using TaskTrackerCLI.Utilities;

namespace TaskTrackerCLI.Tests.Utilities
{
    public class JsonMapperTests
    {
        AppTask task1 = new AppTask(1, "Test Task 1");
        AppTask task2 = new AppTask(2, "Test Task 2");
        AppTask task3 = new AppTask(3, "Test Task 3");
        List<AppTask> TestTaskList => new List<AppTask> { task1, task2, task3 };

        string testJson = new StreamReader(
            @"..\..\..\..\TaskTrackerCLI.Tests\Resources\test.json"
        ).ReadToEnd();

        [Fact]
        public void Serialize_task_to_json()
        {
            string actualJson = JsonMapper.AllTasksToJson(TestTaskList);
            Assert.Equal(testJson, actualJson);
        }

        [Fact]
        public void Deserialize_json_to_task()
        {
            List<AppTask> actualTaskList = JsonMapper.JsonToAllTasks(testJson);
            Assert.Equal(TestTaskList, actualTaskList);
        }
    }
}
