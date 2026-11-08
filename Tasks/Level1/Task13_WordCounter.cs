using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task13_WordCounter : ITask
{
    public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
    
    public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";
    
    public string[] Requirements => new[] 
    { 
        "Использовать Dictionary<string, int>", 
        "Разбить текст на слова (по пробелам и знакам пунктуации)", 
        "Привести слова к нижнему регистру", 
        "Вывести пары «слово → количество», отсортированные по убыванию количества" 
    };

    public void Run()
    {
        Console.WriteLine("Введите текст:");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Ошибка: текст не может быть пустым!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        MatchCollection matches = Regex.Matches(input.ToLower(), @"\b[а-яёa-z0-9]+\b");
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (Match match in matches)
        {
            string word = match.Value;
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordCounts);
        sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        Console.WriteLine("\nРезультат (слово → количество):");
        foreach (var pair in sortedList)
        {
            Console.WriteLine($"{pair.Key} → {pair.Value}");
        }

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}