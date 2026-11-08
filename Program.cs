using System;
using Main.Common;
using Main.Tasks.Level1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый");
            Console.WriteLine("2. Выход");
            Console.Write("\nВыберите пункт: ");

            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                ShowLevel1Menu();
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }

    static void ShowLevel1Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Уровень 1: Базовый ---");
            Console.WriteLine("1. Hello, World + текущая дата");
            Console.WriteLine("2. Переменные примитивных типов");
            Console.WriteLine("3. Калькулятор с обработкой деления на ноль");
            Console.WriteLine("4. Чётность числа (два способа)");
            Console.WriteLine("5. Таблица умножения 10×10");
            Console.WriteLine("6. Сумма цифр числа (строка + арифметика)");
            Console.WriteLine("7. Реверс строки без LINQ");
            Console.WriteLine("8. FizzBuzz 1–100");
            Console.WriteLine("9. Массивы: min/max/sum/avg");
            Console.WriteLine("10. Факториал числа (цикл и рекурсия)");
            Console.WriteLine("11. Диагональ матрицы N×N");
            Console.WriteLine("12. Палиндром (без учёта регистра/пробелов)");
            Console.WriteLine("13. Счётчик вхождений слов в тексте (Dictionary)");
            Console.WriteLine("14. Возраст по дате рождения");
            Console.WriteLine("15. Назад в главное меню");
            Console.Write("\nВыберите задание: ");

            string? choice = Console.ReadLine();
            
            if (choice == "1")
            {
                RunTask(new Task01_HelloWorld());
            }
            else if (choice == "2")
            {
                RunTask(new Task02_Primitives());
            }
            else if (choice == "3")
            {
                RunTask(new Task03_Calculator());
            }
            else if (choice == "4")
            {
                RunTask(new Task04_EvenOrOdd());
            }
            else if (choice == "5")
            {
                RunTask(new Task05_MultiplicationTable());
            }
            else if (choice == "6")
            {
                RunTask(new Task06_DigitSum());
            }
            else if (choice == "7")
            {
                RunTask(new Task07_StringReverse());
            }
            else if (choice == "8")
            {
                RunTask(new Task08_FizzBuzz());
            }
            else if (choice == "9")
            {
                RunTask(new Task09_ArrayStats());
            }
            else if (choice == "10")
            {
                RunTask(new Task10_Factorial());
            }
            else if (choice == "11")
            {
                RunTask(new Task11_MatrixDiagonal());
            }
            else if (choice == "12")
            {
         RunTask(new Task12_Palindrome());
            }
            else if (choice == "13")
            {
                RunTask(new Task13_WordCounter());
            }
            else if (choice == "14")
            {
                RunTask(new Task14_AgeCalculator());
            }
            else if (choice == "15")
            {
                break;
            }
        }
    }

    static void RunTask(ITask task)
    {
        Console.Clear();
        Console.WriteLine($"Задание: {task.Title}");
        Console.WriteLine($"Описание: {task.Description}\n");
        
        Console.WriteLine("Требования:");
        foreach (var req in task.Requirements)
        {
            Console.WriteLine($" - {req}");
        }
        Console.WriteLine(new string('-', 30) + "\n");

        task.Run();
    }
}