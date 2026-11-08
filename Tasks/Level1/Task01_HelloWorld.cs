using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task01_HelloWorld : ITask
{
    public string Title => "Hello, World и текущая дата";
    
    public string Description => "Простейшая программа, которая выводит приветствие и актуальную системную дату.";
    
    public string[] Requirements => new[] 
    { 
        "Вывести приветственное сообщение на консоль", 
        "Вывести текущую дату в формате dd.MM.yyyy" 
    };

    public void Run()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
        Console.WriteLine("\nЗадание выполнено успешно! Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }
}