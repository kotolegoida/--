using System.Text.Json.Serialization;

namespace Main.Tasks.Level3.Todo
{
    public class TaskItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("isDone")]
        public bool IsDone { get; set; }
    }
}