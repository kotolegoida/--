using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Task20_Generics : ITask
    {
        public string Title => "Обобщения: Swap<T>, Max<T>";
        public string Description => "Реализация обобщенных методов Swap и Max с использованием ограничений IComparable.";
        public string[] Requirements => new[]
        {
            "Swap<T>(ref T a, ref T b) — меняет значения местами (без ограничений).",
            "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.",
            "Продемонстрировать на int, string, double."
        };

        public void Run()
        {
            int x = 5, y = 10;
            Console.WriteLine($"До Swap (int): x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"После Swap (int): x = {x}, y = {y}");

            string s1 = "alpha", s2 = "beta";
            Console.WriteLine($"\nДо Swap (string): s1 = {s1}, s2 = {s2}");
            Swap(ref s1, ref s2);
            Console.WriteLine($"После Swap (string): s1 = {s1}, s2 = {s2}");

            Console.WriteLine($"\nMax(10, 20) [int]: {Max(10, 20)}");
            Console.WriteLine($"Max(\"apple\", \"banana\") [string]: {Max("apple", "banana")}");
            Console.WriteLine($"Max(5.5, 3.14) [double]: {Max(5.5, 3.14)}");
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}