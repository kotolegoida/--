using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task04_EvenOrOdd : ITask
{
    public string Title => "Чётность числа (два способа)";
    
    public string Description => "Определяет, чётное ли введённое число, используя два разных метода проверки.";
    
    public string[] Requirements => new[] 
    { 
        "Способ 1: через оператор остатка от деления (% 2 == 0)", 
        "Способ 2: через тернарный оператор (? :)", 
        "Оба способа реализовать отдельными методами", 
        "Вывести результат обоих способов" 
    };

    public void Run()
    {
        Console.Write("Введите целое число: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Ошибка: введено не целое число!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\n--- Результаты проверки ---");
        
        // Способ 1
        bool result1 = IsEvenMethod1(number);
        Console.WriteLine($"Способ 1 (% 2 == 0): число {number} чётное? -> {result1}");

        // Способ 2
        bool result2 = IsEvenMethod2(number);
        Console.WriteLine($"Способ 2 (тернарный): число {number} чётное? -> {result2}");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private bool IsEvenMethod1(int n)
    {
        return n % 2 == 0;
    }

    private bool IsEvenMethod2(int n)
    {
        return (n % 2 == 0) ? true : false;
    }
}