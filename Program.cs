using System;
using Main.Common;
using Main.Tasks.Level1;
using Main.Tasks.Level2;
using Main.Tasks.Level3;

partial class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый");
            Console.WriteLine("2. Уровень 2 — Средний");
            Console.WriteLine("3. Уровень 3 — Продвинутый");
            Console.WriteLine("4. Выход");
            Console.Write("\nВыберите пункт: ");

            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                ShowLevel1Menu();
            }
            else if (choice == "2")
            {
           ShowLevel2Menu();
            }
            else if (choice == "3")
            {
                ShowLevel3Menu(); 
            }
            else if (choice == "4")
            {
                break;
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
            
            if (choice == "1") RunTask(new Task01_HelloWorld());
            else if (choice == "2") RunTask(new Task02_Primitives());
            else if (choice == "3") RunTask(new Task03_Calculator());
            else if (choice == "4") RunTask(new Task04_EvenOrOdd());
            else if (choice == "5") RunTask(new Task05_MultiplicationTable());
            else if (choice == "6") RunTask(new Task06_DigitSum());
            else if (choice == "7") RunTask(new Task07_StringReverse());
            else if (choice == "8") RunTask(new Task08_FizzBuzz());
            else if (choice == "9") RunTask(new Task09_ArrayStats());
            else if (choice == "10") RunTask(new Task10_Factorial());
            else if (choice == "11") RunTask(new Task11_MatrixDiagonal());
            else if (choice == "12") RunTask(new Task12_Palindrome());
            else if (choice == "13") RunTask(new Task13_WordCounter());
            else if (choice == "14") RunTask(new Task14_AgeCalculator());
            else if (choice == "15") break;
        }
    }

    static void ShowLevel2Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Уровень 2: Средний ---");
            Console.WriteLine("16. Методы расширения для string");
            Console.WriteLine("17. StringBuilder vs конкатенация");
            Console.WriteLine("18. TryParse vs try/catch");
            Console.WriteLine("19. Свой стек/очередь на массиве");
            Console.WriteLine("20. Обобщения: Swap<T>, Max<T>");
            Console.WriteLine("21. enum дни недели");
            Console.WriteLine("22. params-метод + перегрузка");
            Console.WriteLine("23. Nullable-типы, ??, ?.");
            Console.WriteLine("24. ООП: Animal → Dog/Cat/Bird");
            Console.WriteLine("25. Интерфейс IShape + сортировка фигур");
            Console.WriteLine("26. Паттерн «Стратегия» (скидки)");
            Console.WriteLine("27. IComparable / IComparer<T> для Student");
            Console.WriteLine("28. Equals / GetHashCode для Point");
            Console.WriteLine("29. Паттерн «Фабрика» (уведомления)");
            Console.WriteLine("30. BankAccount + свой Exception");
            Console.WriteLine("31. IDisposable + using");
            Console.WriteLine("32. Свойства с валидацией (Temperature)");
            Console.WriteLine("33. LINQ: сотрудники (top-3, avg по отделу, фильтр)");
            Console.WriteLine("34. LINQ: группировка слов по первой букве");
            Console.WriteLine("36. Назад в главное меню");
            Console.Write("\nВыберите задание: ");

            string? choice = Console.ReadLine();
            
            if (choice == "16")
            {
                Console.Clear();
                Console.WriteLine("=== Задание 16. Методы расширения для string ===");
                Console.WriteLine("Требования: public static методы IsPalindrome(), WordCount(), ReverseString() для string.\n");

                string sample = "Hello CSharp World";
                string palindromeStr = "Шалаш";

                Console.WriteLine($"Исходная строка: \"{sample}\"");
                Console.WriteLine($"Перевернутая строка (ReverseString): \"{sample.ReverseString()}\"");
                Console.WriteLine($"Количество слов (WordCount): {sample.WordCount()}");
                Console.WriteLine($"Является ли \"{palindromeStr}\" палиндромом (IsPalindrome): {palindromeStr.IsPalindrome()}");

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
            else if (choice == "17") RunTask(new Task17_StringPerformance());
            else if (choice == "18") RunTask(new Task18_TryParseVsTryCatch());
            else if (choice == "19") RunTask(new Task19_CustomCollections());
            else if (choice == "20") RunTask(new Task20_Generics());
            else if (choice == "21") RunTask(new Task21_DayOfWeekEnum());
            else if (choice == "22") RunTask(new Task22_ParamsAndOverload());
            else if (choice == "23") RunTask(new Task23_NullableTypes());
            else if (choice == "24") RunTask(new Task24_AnimalHierarchy());
            else if (choice == "25") RunTask(new Task25_ShapeSorting());
            else if (choice == "26") RunTask(new Task26_StrategyDiscount());
            else if (choice == "27") RunTask(new Task27_StudentSorting());
            else if (choice == "28") RunTask(new Task28_PointEquality());
            else if (choice == "29") RunTask(new Task29_NotificationFactory());
            else if (choice == "30") RunTask(new Task30_BankAccountException());
            else if (choice == "31") RunTask(new Task31_DisposableFileWriter());
            else if (choice == "32") RunTask(new Task32_TemperatureValidation());
            else if (choice == "33") RunTask(new Task33_EmployeeLinq());
            else if (choice == "34") RunTask(new Task34_WordGrouping());
            else if (choice == "36" || choice == "35") break;
        }
    }
    static void ShowLevel3Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Уровень 3: Продвинутый ---");
            Console.WriteLine("36. Дубликаты в List (HashSet + GroupBy)");
            Console.WriteLine("37. Мемоизация Фибоначчи через Dictionary");
            Console.WriteLine("38. List<T> vs LinkedList<T> (бенчмарк)");
            Console.WriteLine("51. Назад в главное меню");
            Console.Write("\nВыберите задание: ");

            string? choice = Console.ReadLine();

            if (choice == "36") RunTask(new Task36_ListDuplicates());
            else if (choice == "37") RunTask(new Task37_FibonacciMemoization());
            else if (choice == "38") RunTask(new Task38_ListVsLinkedList());
            else if (choice == "51") break;
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
            Console.WriteLine($"- {req}");
        }
        Console.WriteLine(new string('-', 30) + "\n");

        task.Run();
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }
    }
}
}