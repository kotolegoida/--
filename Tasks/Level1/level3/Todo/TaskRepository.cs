using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Main.Tasks.Level3.Todo
{
    public class TaskRepository
    {
        private readonly string _filePath = "tasks.json";

        public List<TaskItem> LoadTasks()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<TaskItem>();
                }

                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch (Exception)
            {
                return new List<TaskItem>();
            }
        }

        public void SaveTasks(List<TaskItem> tasks)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}