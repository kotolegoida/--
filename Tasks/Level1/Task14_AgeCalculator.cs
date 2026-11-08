using System;
using Main.Common;

namespace Main.Tasks.Level1;

public class Task14_AgeCalculator : ITask
{
    public string Title => "Возраст по дате рождения";
    
    public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";
    
    public string[] Requirements => new[] 
    { 
        "Ввод даты через DateTime.TryParse", 
        "Учесть, что день рождения в этом году мог ещё не наступить", 
        "Вывести «X лет, Y месяцев, Z дней»", 
        "Некорректная дата — сообщение об ошибке, не падать" 
    };

    public void Run()
    {
        Console.Write("Введите дату рождения (например, ДД.ММ.ГГГГ): ");
        string? input = Console.ReadLine();

        if (!DateTime.TryParse(input, out DateTime birthDate))
        {
            Console.WriteLine("Ошибка: некорректная дата! Приложение не падает.");
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadLine();
            return;
        }

        DateTime today = DateTime.Today;

        if (birthDate > today)
        {
            Console.WriteLine("Ошибка: дата рождения из будущего!");
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            Console.ReadLine();
            return;
        }

        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;

        if (days < 0)
        {
            months--;
            DateTime previousMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        Console.WriteLine($"\nВозраст: {years} лет, {months} месяцев, {days} дней.");

        Console.WriteLine("\nЗадание выполнено. Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}