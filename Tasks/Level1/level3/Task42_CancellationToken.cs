using System;
using System.Threading;
using System.Threading.Tasks;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task42_CancellationToken : ITask
    {
        public string Title => "CancellationToken — отмена асинхронной задачи";
        public string Description => "Реализация долгой операции с возможностью досрочной отмены через CancellationTokenSource за 2 секунды.";
        public string[] Requirements => new[]
        {
            "Создать async Task LongOperationAsync(CancellationToken token) с циклом и задержками.",
            "Использовать CancellationTokenSource для автоматической отмены через 2 секунды.",
            "Перехватить OperationCanceledException и вывести сообщение об отмене.",
            "Убедиться, что приложение не падает и корректно завершает работу."
        };

        public void Run()
        {
            RunCancellationDemo().GetAwaiter().GetResult();
        }
        private async Task RunCancellationDemo()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

            Console.WriteLine("Запуск долгой операции (планируется 10 шагов по 500 мс)...");
            Console.WriteLine("Операция будет автоматически отменена через 2 секунды.\n");
            try
            {
                await LongOperationAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n[Поймано исключение]: Операция была успешно отменена по токену!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("CancellationToken позволяет безопасно и вовремя останавливать фоновые процессы, экономя ресурсы процессора и сети.");
        }

        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Выполнение шага {i} из 10...");
                await Task.Delay(500, token);
            }
            Console.WriteLine("Долгая операция успешно завершена (без отмены).");
        }
    }
}