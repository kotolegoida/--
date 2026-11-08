using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task03_Calculator : ITask
{
    public string Title => "Калькулятор с обработкой деления на ноль";
    
    public string Description => "Принимает два числа и оператор (+, -, *, /), выводит результат. Обработать деление на ноль.";
    
    public string[] Requirements => new[] 
    { 
        "Использовать switch для оператора", 
        "Не допускать падения при делении на ноль", 
        "Обработать некорректный оператор («Неизвестная операция»)", 
        "Ввод чисел через double.TryParse" 
    };

    public void Run()
    {
        Console.Write("Введите первое число: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Ошибка: неверный формат числа!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        Console.Write("Введите оператор (+, -, *, /): ");
        string? op = Console.ReadLine();

        Console.Write("Введите второе число: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Ошибка: неверный формат числа!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        double result = 0;
        bool success = true;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно!");
                    success = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                success = false;
                break;
        }

        if (success)
        {
            Console.WriteLine($"Результат: {num1} {op} {num2} = {result}");
        }

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}