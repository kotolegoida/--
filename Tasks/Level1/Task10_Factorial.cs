using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task10_Factorial : ITask
{
    public string Title => "Факториал числа (цикл и рекурсия)";
    
    public string Description => "Вычисляет факториал введенного неотрицательного целого числа двумя способами.";
    
    public string[] Requirements => new[] 
    { 
        "Способ 1: вычисление через цикл", 
        "Способ 2: вычисление через рекурсию", 
        "Использовать тип long для защиты от переполнения", 
        "Проверка корректности ввода и отрицательных чисел" 
    };

    public void Run()
    {
        Console.Write("Введите целое неотрицательное число (0-20): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("Ошибка: введено некорректное или отрицательное число!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        if (n > 20)
        {
            Console.WriteLine("Ошибка: число слишком велико, произошло бы переполнение типа long!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\n--- Результаты вычислений ---");

        long resultIterative = CalculateFactorialIterative(n);
        Console.WriteLine($"Факториал {n}! (через цикл) = {resultIterative}");

        long resultRecursive = CalculateFactorialRecursive(n);
        Console.WriteLine($"Факториал {n}! (через рекурсию) = {resultRecursive}");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private long CalculateFactorialIterative(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    private long CalculateFactorialRecursive(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        return n * CalculateFactorialRecursive(n - 1);
    }
}