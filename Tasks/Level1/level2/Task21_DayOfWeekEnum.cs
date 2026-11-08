using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public enum DayOfWeekEnum
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Task21_DayOfWeekEnum : ITask
    {
        public string Title => "enum дни недели";
        public string Description => "Определение дней недели через enum, проверка на выходной и получение русского названия.";
        public string[] Requirements => new[]
        {
            "enum DayOfWeekEnum { Monday, ..., Sunday }.",
            "Метод IsWeekend(DayOfWeekEnum day) — true для субботы и воскресенья.",
            "Метод GetRussianName(DayOfWeekEnum day) — возвращает название на русском.",
            "Продемонстрировать на всех 7 днях."
        };

        public void Run()
        {
            foreach (DayOfWeekEnum day in Enum.GetValues(typeof(DayOfWeekEnum)))
            {
                string rusName = GetRussianName(day);
                bool isWeekend = IsWeekend(day);
                
                Console.WriteLine($"День: {day,-10} | Русский: {rusName,-12} | Выходной: {isWeekend}");
            }
        }

        private bool IsWeekend(DayOfWeekEnum day)
        {
            return day == DayOfWeekEnum.Saturday || day == DayOfWeekEnum.Sunday;
        }

        private string GetRussianName(DayOfWeekEnum day)
        {
            return day switch
            {
                DayOfWeekEnum.Monday => "Понедельник",
                DayOfWeekEnum.Tuesday => "Вторник",
                DayOfWeekEnum.Wednesday => "Среда",
                DayOfWeekEnum.Thursday => "Четверг",
                DayOfWeekEnum.Friday => "Пятница",
                DayOfWeekEnum.Saturday => "Суббота",
                DayOfWeekEnum.Sunday => "Воскресенье",
                _ => "Неизвестно"
            };
        }
    }
}