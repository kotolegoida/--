using System;
using System.Text;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task12_Palindrome : ITask
{
    public string Title => "Палиндром (без учёта регистра/пробелов)";
    
    public string Description => "Проверить, является ли строка палиндромом.";
    
    public string[] Requirements => new[] 
    { 
        "Игнорировать регистр (ToLower/ToUpper)", 
        "Игнорировать пробелы и знаки пунктуации", 
        "Не использовать LINQ Reverse", 
        "Пустая строка и строка из одного символа — палиндром" 
    };

    public void Run()
    {
        Console.Write("Введите строку для проверки: ");
        string? input = Console.ReadLine();

        bool result = IsPalindrome(input);

        Console.WriteLine($"\nРезультат: строка {(result ? "является" : "не является")} палиндромом.");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private bool IsPalindrome(string? s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        // Очищаем строку от пробелов, пунктуации и приводим к нижнему регистру
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(char.ToLower(c));
            }
        }

        string cleaned = sb.ToString();

        if (cleaned.Length <= 1)
        {
            return true;
        }

        // Проверка на палиндром без использования LINQ Reverse
        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}