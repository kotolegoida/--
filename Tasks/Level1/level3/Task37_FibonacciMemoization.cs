using System;
using System.Collections.Generic;
using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task37_FibonacciMemoization : ITask
    {
        public string Title => "Мемоизация Фибоначчи через Dictionary";
        public string Description => "Сравнение производительности обычной рекурсии и рекурсии с мемоизацией при вычислении чисел Фибоначчи.";
        public string[] Requirements => new[]
        {
            "Обычная рекурсивная версия.",
            "Мемоизированная версия с Dictionary<int, long>.",
            "Замерить время обеих на N = 35 через Stopwatch.",
            "Вывести оба времени и разницу."
        };

        private Dictionary<int, long> _memo = new Dictionary<int, long>();

        public void Run()
        {
            int n = 35;
            Console.WriteLine($"Вычисление чисел Фибоначчи для N = {n}\n");

            Stopwatch sw = Stopwatch.StartNew();
            long ordinaryResult = FibonacciOrdinary(n);
            sw.Stop();
            long ordinaryTicks = sw.ElapsedMilliseconds;

            Console.WriteLine($"Обычная рекурсия:");
            Console.WriteLine($"  Результат: {ordinaryResult}");
            Console.WriteLine($"  Время: {ordinaryTicks} мс\n");

            _memo.Clear();

            sw.Restart();
            long memoResult = FibonacciMemoized(n);
            sw.Stop();
            long memoTicks = sw.ElapsedMilliseconds;

            Console.WriteLine($"Мемоизированная рекурсия (Dictionary):");
            Console.WriteLine($"  Результат: {memoResult}");
            Console.WriteLine($"  Время: {memoTicks} мс\n");

            Console.WriteLine("Вывод:");
            Console.WriteLine("Мемоизированная версия работает мгновенно за счет кэширования результатов в Dictionary.");
        }

        private long FibonacciOrdinary(int n)
        {
            if (n <= 1) return n;
            return FibonacciOrdinary(n - 1) + FibonacciOrdinary(n - 2);
        }

        private long FibonacciMemoized(int n)
        {
            if (n <= 1) return n;

            if (_memo.ContainsKey(n))
            {
                return _memo[n];
            }

            long result = FibonacciMemoized(n - 1) + FibonacciMemoized(n - 2);
            _memo[n] = result;

            return result;
        }
    }
}