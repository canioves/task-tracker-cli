using TaskTrackerCLI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskTrackerCLI.Utilities
{
    public class JsonMapper
    {
        private static JsonSerializerOptions _serializerOptions;
        static JsonMapper()
        {
            _serializerOptions = new JsonSerializerOptions();
            _serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            _serializerOptions.Converters.Add(new JsonStringEnumConverter());
            _serializerOptions.WriteIndented = true;
        }
        public static string AllTasksToJson(List<AppTask> taskList) => JsonSerializer.Serialize(taskList, _serializerOptions);
        public static List<AppTask> JsonToAllTasks(string json) => JsonSerializer.Deserialize<List<AppTask>>(json, _serializerOptions);
    }
}