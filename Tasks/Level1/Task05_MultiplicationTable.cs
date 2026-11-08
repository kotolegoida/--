using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task05_MultiplicationTable : ITask
{
    public string Title => "Таблица умножения 10×10";
    
    public string Description => "Выводит на консоль таблицу умножения от 1 до 10 с выравниванием столбцов.";
    
    public string[] Requirements => new[] 
    { 
        "Использовать вложенные циклы for", 
        "Выровнять столбцы", 
        "Вывести все 100 значений" 
    };

    public void Run()
    {
        Console.WriteLine("Таблица умножения 10×10:\n");

        // Вывод заголовка столбцов
        Console.Write("    ");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i,4}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 45));

        // Основные строки таблицы
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i,2} |");
            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}