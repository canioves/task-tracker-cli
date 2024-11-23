using TaskTrackerCLI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskTrackerCLI.Utilities
{
    public class JsonMapper
    {
        private JsonSerializerOptions _serializerOptions;
        public JsonMapper(string jsonPath)
        {
            string dbFileName = "taskDB.json";
            string actualPath = Path.GetFullPath(Path.Combine(@"..\..\..\..", jsonPath, dbFileName));

            _serializerOptions = new JsonSerializerOptions();
            _serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            _serializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        public string TaskToJson(AppTask task) => JsonSerializer.Serialize(task, _serializerOptions);

        public AppTask JsonToTask(string json) => JsonSerializer.Deserialize<AppTask>(json, _serializerOptions);
    }
}