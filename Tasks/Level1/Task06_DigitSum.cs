using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task06_DigitSum : ITask
{
    public string Title => "Сумма цифр числа (строка + арифметика)";
    
    public string Description => "Находит сумму цифр введённого числа двумя способами: через преобразование в строку и через арифметические операции.";
    
    public string[] Requirements => new[] 
    { 
        "Способ 1 (строка): ToString() -> пройти по символам -> int.Parse", 
        "Способ 2 (арифметика): цикл while с делением и остатком", 
        "Оба способа оформить отдельными методами", 
        "Отрицательные числа — брать модуль" 
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

        Console.WriteLine("\n--- Результаты вычислений ---");
        
        int sumString = SumByString(number);
        Console.WriteLine($"Способ 1 (через строку): сумма цифр числа {number} = {sumString}");

        int sumArithmetic = SumByArithmetic(number);
        Console.WriteLine($"Способ 2 (арифметика): сумма цифр числа {number} = {sumArithmetic}");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private int SumByString(int n)
    {
        string s = Math.Abs(n).ToString();
        int sum = 0;
        foreach (char c in s)
        {
            sum += int.Parse(c.ToString());
        }
        return sum;
    }

    private int SumByArithmetic(int n)
    {
        int sum = 0;
        int temp = Math.Abs(n);
        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }
        return sum;
    }
}