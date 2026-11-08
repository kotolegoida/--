using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task09_ArrayStats : ITask
{
    public string Title => "Массивы: min/max/sum/avg";
    
    public string Description => "Для массива чисел найти минимум, максимум, сумму и среднее.";
    
    public string[] Requirements => new[] 
    { 
        "Заполнить массив (например, случайными числами 1–100, размер 20)", 
        "Реализовать без LINQ (Min/Max/Sum/Average запрещены)", 
        "Оформить 4 отдельных метода", 
        "Пустой массив — обработать (вернуть ошибку или 0, но не падать)" 
    };

    public void Run()
    {
        int[] numbers = new int[20];
        Random rand = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(1, 101);
        }

        Console.WriteLine("Сгенерированный массив:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine(new string('-', 30));

        int min = GetMin(numbers);
        int max = GetMax(numbers);
        long sum = GetSum(numbers);
        double avg = GetAverage(numbers);

        Console.WriteLine($"Минимум: {min}");
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Среднее арифметическое: {avg:F2}");

        Console.WriteLine("\nПроверка пустого массива:");
        int[] emptyArray = Array.Empty<int>();
        Console.WriteLine($"Пустой массив — Мин: {GetMin(emptyArray)}, Макс: {GetMax(emptyArray)}, Сумма: {GetSum(emptyArray)}, Среднее: {GetAverage(emptyArray)}");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    private int GetMin(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;
        
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }

    private int GetMax(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    private long GetSum(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    private double GetAverage(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        return (double)GetSum(arr) / arr.Length;
    }
}