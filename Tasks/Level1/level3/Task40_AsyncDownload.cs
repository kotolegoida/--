using System;
using System.Threading.Tasks;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task40_AsyncDownload : ITask
    {
        public string Title => "Async/Await и обработка исключений";
        public string Description => "Эмуляция асинхронного скачивания данных с обработкой ошибок для пустых URL.";
        public string[] Requirements => new[]
        {
            "Создать async Task<string> DownloadAsync(string url) с Task.Delay(1000).",
            "Если url пустой или null — выбросить ArgumentException.",
            "В Main (Run) вызвать метод через await внутри try/catch.",
            "Продемонстрировать как успешный, так и ошибочный вызов."
        };

        public void Run()
        {
            RunAsyncDemo().GetAwaiter().GetResult();
        }

        private async Task RunAsyncDemo()
        {
            Console.WriteLine("--- Сценарий 1: Успешное скачивание ---");
            try
            {
                string validUrl = "https://example.com/data.json";
                Console.WriteLine($"Начинаем скачивание из: {validUrl}...");
                string result = await DownloadAsync(validUrl);
                Console.WriteLine($"Успех! Получено данных: {result.Length} символов.");
                Console.WriteLine($"Содержимое: \"{result}\"\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
            Console.WriteLine("--- Сценарий 2: Ошибка (пустой URL) ---");
            try
            {
                string invalidUrl = "";
                Console.WriteLine($"Начинаем скачивание из: \"{invalidUrl}\"...");
                
                string result = await DownloadAsync(invalidUrl);
                
                Console.WriteLine($"Успех! Получено данных: {result.Length} символов.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено ожидаемое исключение: {ex.Message}");
                Console.WriteLine("Приложение продолжило работу стабильно!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}\n");
            }

            Console.WriteLine("Результат:");
            Console.WriteLine("Использование async/await позволяет не блокировать поток во время ожидания (Task.Delay), а конструкция try/catch надежно защищает программу от падения при некорректных данных.");
        }

        private async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL не может быть пустым или состоять только из пробелов.", nameof(url));
            }
            await Task.Delay(1000);
            return $"Эмулированные данные из источника: {url}";
        }
    }
}