using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task02_Primitives : ITask
{
    public string Title => "Переменные примитивных типов";
    
    public string Description => "Объявление переменных всех основных примитивных типов C# с выводом их значений и типов.";
    
    public string[] Requirements => new[] 
    { 
        "Объявить минимум: int, long, double, float, decimal, bool, char, string", 
        "Вывести значение и GetType().Name для каждой переменной", 
        "Использовать правильные суффиксы для decimal (m) и float (f)" 
    };

    public void Run()
    {
        int intVal = 42;
        long longVal = 10000000000L;
        double doubleVal = 3.14159;
        float floatVal = 2.71f;
        decimal decimalVal = 199.99m;
        bool boolVal = true;
        char charVal = 'A';
        string stringVal = "Привет!";

        Console.WriteLine($"intVal = {intVal} (тип: {intVal.GetType().Name})");
        Console.WriteLine($"longVal = {longVal} (тип: {longVal.GetType().Name})");
        Console.WriteLine($"doubleVal = {doubleVal} (тип: {doubleVal.GetType().Name})");
        Console.WriteLine($"floatVal = {floatVal} (тип: {floatVal.GetType().Name})");
        Console.WriteLine($"decimalVal = {decimalVal} (тип: {decimalVal.GetType().Name})");
        Console.WriteLine($"boolVal = {boolVal} (тип: {boolVal.GetType().Name})");
        Console.WriteLine($"charVal = {charVal} (тип: {charVal.GetType().Name})");
        Console.WriteLine($"stringVal = {stringVal} (тип: {stringVal.GetType().Name})");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}