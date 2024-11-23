using TaskTrackerCLI.Models;
using TaskTrackerCLI.Utilities;

namespace TaskTrackerCLI.Tests.Utilities
{
    public class JsonMapperTests
    {
        AppTask testTask = new AppTask(1, "Test task");
        JsonMapper mapper = new JsonMapper(@"TaskTrackerCLI.Tests\DB");
        string testJson = @"{""id"":1,""description"":""Test task"",""status"":""TODO"",""createdAt"":null,""updatedAt"":null}";

        [Fact]
        public void Serialize_task_to_json()
        {
            string actualJson = mapper.TaskToJson(testTask);            
            Assert.Equal(testJson, actualJson);
        }

        [Fact]
        public void Deserialize_json_to_task()
        {
            AppTask actualTask = mapper.JsonToTask(testJson);
            Assert.Equal(testTask, actualTask);
        }
    }
}