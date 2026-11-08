using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Task18_TryParseVsTryCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнение обработки некорректного ввода числа через int.TryParse и try/catch.";
        public string[] Requirements => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out.",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."
        };

        public void Run()
        {
            string[] testInputs = { "123", "abc", "-42", "3.14" };

            foreach (var input in testInputs)
            {
                Console.WriteLine($"\nТестируем ввод: \"{input}\"");

                // Способ 1: TryParse
                bool successTryParse = TestTryParse(input, out int resultTryParse);
                if (successTryParse)
                {
                    Console.WriteLine($"  [TryParse] Успех: {resultTryParse}");
                }
                else
                {
                    Console.WriteLine("  [TryParse] Ошибка: не удалось преобразовать в число.");
                }

                // Способ 2: try/catch + int.Parse
                try
                {
                    int resultParse = TestTryCatch(input);
                    Console.WriteLine($"  [try/catch] Успех: {resultParse}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("  [try/catch] Пойман FormatException: некорректный формат строки.");
                }
            }
        }

        private bool TestTryParse(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        private int TestTryCatch(string input)
        {
            return int.Parse(input);
        }
    }
}