using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task41_TaskWhenAll : ITask
    {
        public string Title => "Task.WhenAll — параллельный запуск задач";
        public string Description => "Сравнение производительности последовательного запуска задач и параллельного через Task.WhenAll.";
        public string[] Requirements => new[]
        {
            "Создать метод Task<int> WorkAsync(int id) с эмуляцией задержки Task.Delay(500).",
            "Выполнить 10 задач последовательно в цикле с await и замерить время.",
            "Выполнить те же 10 задач параллельно через Task.WhenAll и замерить время.",
            "Вывести оба времени и объяснить разницу."
        };
        public void Run()
        {
            RunWhenAllDemo().GetAwaiter().GetResult();
        }
        private async Task RunWhenAllDemo()
        {
            int taskCount = 10;
            int delayMs = 500;
            Console.WriteLine($"Запуск {taskCount} задач (каждая с задержкой {delayMs} мс)...\n");
            var sw = Stopwatch.StartNew();
            for (int i = 1; i <= taskCount; i++)
            {
                await WorkAsync(i, delayMs);
            }
            sw.Stop();
            long sequentialTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Время последовательного выполнения: {sequentialTime} мс\n");
            sw.Restart();
            var tasks = new Task<int>[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = WorkAsync(i + 1, delayMs);
            }
            int[] results = await Task.WhenAll(tasks);
            sw.Stop();
            long parallelTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Время параллельного выполнения (WhenAll): {parallelTime} мс");
            Console.WriteLine($"Полученные результаты: {string.Join(", ", results)}\n");
            Console.WriteLine("Результат:");
            Console.WriteLine("Параллельный вариант работает значительно быстрее, так как задачи выполняются одновременно. При последовательном запуске время суммируется (500 мс * 10 = ~5000 мс), а при WhenAll общее время равно времени выполнения одной самой долги (~500 мс).");
        }
        private async Task<int> WorkAsync(int id, int delay)
        {
            await Task.Delay(delay);
            return id;
        }
    }
}