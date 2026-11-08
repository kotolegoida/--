using System;
using System.Collections.Generic;
using System.Linq;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Task34_WordGrouping : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "Группировка списка слов по первой букве с использованием LINQ (GroupBy, OrderBy, ThenBy) и сортировкой внутри групп.";
        public string[] Requirements => new[]
        {
            "Взять список слов (10+).",
            "Сгруппировать через LINQ GroupBy(w => w[0]).",
            "Отсортировать группы по первой букве.",
            "Внутри группы — отсортировать слова.",
            "Вывести «Буква: слово1, слово2, ...»."
        };

        public void Run()
        {
            List<string> words = new List<string>
            {
                "Программирование", "Алгоритм", "База", "Класс", 
                "Интерфейс", "Архитектура", "Компилятор", "Метод", 
                "Объект", "Переменная", "Строка", "Функция", "Массив"
            };
            Console.WriteLine("--- Исходный список слов ---");
            Console.WriteLine(string.Join(", ", words));
            var groupedWords = words
                .Select(w => w.Trim())
                .Where(w => !string.IsNullOrEmpty(w))
                .GroupBy(w => char.ToUpper(w[0])) 
                .Select(g => new
                {
                    Letter = g.Key,
                    Words = g.OrderBy(w => w, StringComparer.CurrentCulture).ToList() 
                })
                .ToList();
            Console.WriteLine("\n--- Сгруппированные и отсортированные слова ---");
            foreach (var group in groupedWords)
            {
                string joinedWords = string.Join(", ", group.Words);
                Console.WriteLine($"{group.Letter}: {joinedWords}");
            }
        }
    }
}