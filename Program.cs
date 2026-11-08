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
            Console.WriteLine("1. Hello, World и текущая дата");
            Console.WriteLine("2. Назад в главное меню");
            Console.Write("\nВыберите задание: ");

            string? choice = Console.ReadLine();
            
            if (choice == "1")
            {
                ITask task = new Task01_HelloWorld();
                Console.Clear();
                Console.WriteLine($"Задание: {task.Title}");
                Console.WriteLine($"Описание: {task.Description}\n");
                
                // Запускаем само задание
                task.Run();
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }
}