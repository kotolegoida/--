using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task08_FizzBuzz : ITask
{
    public string Title => "FizzBuzz 1–100";
    
    public string Description => "Вывести числа от 1 до 100 с заменами.";
    
    public string[] Requirements => new[] 
    { 
        "Кратно 3 → Fizz", 
        "Кратно 5 → Buzz", 
        "Кратно 15 → FizzBuzz", 
        "Иначе — само число",
        "Порядок проверок: сначала 15, потом 3 и 5" 
    };

    public void Run()
    {
        Console.WriteLine("Результат выполнения FizzBuzz (1–100):\n");

        for (int i = 1; i <= 100; i++)
        {
            if (i % 15 == 0)
            {
                Console.Write("FizzBuzz ");
            }
            else if (i % 3 == 0)
            {
                Console.Write("Fizz ");
            }
            else if (i % 5 == 0)
            {
                Console.Write("Buzz ");
            }
            else
            {
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine("\n\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}