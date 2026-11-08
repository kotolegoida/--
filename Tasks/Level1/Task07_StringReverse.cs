using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task07_StringReverse : ITask
{
    public string Title => "Реверс строки без LINQ";
    
    public string Description => "Перевернуть введённую строку.";
    
    public string[] Requirements => new[] 
    { 
        "Не использовать Array.Reverse и LINQ", 
        "Реализовать через цикл for от конца к началу (или через char[] и swap)", 
        "Пустая строка и строка из одного символа — обрабатываются корректно" 
    };

    public void Run()
    {
        Console.Write("Введите строку для реверса: ");
        string? input = Console.ReadLine();

        if (input == null)
        {
            input = string.Empty;
        }

        string reversed = ReverseString(input);

        Console.WriteLine($"Исходная строка: \"{input}\"");
        Console.WriteLine($"Перевернутая строка: \"{reversed}\"");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private string ReverseString(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1)
        {
            return s;
        }

        char[] chars = s.ToCharArray();
        for (int i = 0; i < chars.Length / 2; i++)
        {
            char temp = chars[i];
            chars[i] = chars[chars.Length - 1 - i];
            chars[chars.Length - 1 - i] = temp;
        }

        return new string(chars);
    }
}