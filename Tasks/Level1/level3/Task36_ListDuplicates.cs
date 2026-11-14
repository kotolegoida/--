using System;
using System.Collections.Generic;
using System.Linq;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task36_ListDuplicates : ITask
    {
        public string Title => "Дубликаты в List";
        public string Description => "Поиск и удаление дубликатов с использованием HashSet и LINQ GroupBy.";
        public string[] Requirements => new[]
        {
            "Создать список с повторяющимися элементами.",
            "Удалить дубликаты через HashSet.",
            "Найти дубликаты через GroupBy.",
            "Вывести результат."
        };

        public void Run()
        {
            var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 1, 6, 3, 7 };
            Console.WriteLine("Исходный список: " + string.Join(", ", numbers));

            var uniqueHashSet = new HashSet<int>(numbers);
            Console.WriteLine("Без дубликатов (HashSet): " + string.Join(", ", uniqueHashSet));

            var duplicates = numbers.GroupBy(x => x)
                                    .Where(g => g.Count() > 1)
                                    .Select(g => g.Key)
                                    .ToList();
            Console.WriteLine("Найденные дубликаты (GroupBy): " + string.Join(", ", duplicates));
        }
    }
}