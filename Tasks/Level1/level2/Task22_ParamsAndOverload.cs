using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Task22_ParamsAndOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Реализация метода подсчета суммы с params int[] и демонстрация вызовов.";
        public string[] Requirements => new[]
        {
            "Sum(params int[] numbers) — сумма произвольного числа чисел.",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] { 1, 2, 3 }), Sum().",
            "Пустой вызов — вернуть 0."
        };

        public void Run()
        {
            int res1 = Sum(1, 2, 3);
            int res2 = Sum(new[] { 1, 2, 3 });
            int res3 = Sum();

            Console.WriteLine($"Sum(1, 2, 3) = {res1}");
            Console.WriteLine($"Sum(new[] {{ 1, 2, 3 }}) = {res2}");
            Console.WriteLine($"Sum() = {res3}");
        }
        private int Sum(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return total;
        }
    }
}