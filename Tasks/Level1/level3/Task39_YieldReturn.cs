using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task39_YieldReturn : ITask
    {
        public string Title => "Итераторы и yield return";
        public string Description => "Реализация ленивой генерации последовательности Фибоначчи и фильтрации чётных чисел с помощью yield return.";
        public string[] Requirements => new[]
        {
            "Создать метод-итератор для бесконечной генерации чисел Фибоначчи.",
            "Создать метод-фильтр для выборки только чётных чисел из последовательности.",
            "Вывести первые 10 сгенерированных чисел через foreach.",
            "Объяснить принцип работы yield return."
        };

        public void Run()
        {
            Console.WriteLine("Первые 10 чисел Фибоначчи (через yield return):");
            int count = 0;
            foreach (var number in GetFibonacciSequence())
            {
                Console.Write($"{number} ");
                count++;
                if (count >= 10) break;
            }
            Console.WriteLine("\n");

            var sourceList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Исходный список: " + string.Join(", ", sourceList));
            
            Console.WriteLine("Только чётные числа (через yield return filter):");
            foreach (var even in GetEvenNumbers(sourceList))
            {
                Console.Write($"{even} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Результат:");
            Console.WriteLine("yield return позволяет возвращать элементы по одному по мере необходимости. Коллекция не создается целиком в памяти, код выполняется лениво (lazy evaluation).");
        }

        private IEnumerable<long> GetFibonacciSequence()
        {
            long prev = 0, current = 1;
            yield return prev;
            yield return current;

            while (true)
            {
                long next = prev + current;
                yield return next;
                prev = current;
                current = next;
            }
        }

        private IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
    }
}