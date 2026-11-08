using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task11_MatrixDiagonal : ITask
{
    public string Title => "Диагональ матрицы N×N";
    
    public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";
    
    public string[] Requirements => new[] 
    { 
        "Размер N вводится пользователем (минимум 2)", 
        "Матрица заполняется случайными числами", 
        "Сумма считается без LINQ, в одном цикле for", 
        "Вывести саму матрицу и сумму" 
    };

    public void Run()
    {
        Console.Write("Введите размер матрицы N (минимум 2): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 2)
        {
            Console.WriteLine("Ошибка: размер N должен быть целым числом не менее 2!");
            Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            return;
        }

        int[,] matrix = new int[n, n];
        Random rand = new Random();

        // Заполнение матрицы случайными числами от 1 до 99
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.Next(1, 100);
            }
        }

        Console.WriteLine($"\nСгенерированная матрица {n}×{n}:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }

        // Вычисление суммы элементов главной диагонали в одном цикле for без LINQ
        int diagonalSum = 0;
        for (int i = 0; i < n; i++)
        {
            diagonalSum += matrix[i, i];
        }

        Console.WriteLine($"\nСумма элементов главной диагонали: {diagonalSum}");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}