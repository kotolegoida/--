using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }
        public int CompareTo(Student? other)
        {
            if (other == null) return 1;
            return other.AverageGrade.CompareTo(this.AverageGrade);
        }

        public override string ToString()
        {
            return $"Студент: {Name,-10} | Средний балл: {AverageGrade:F2}";
        }
    }

    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    public class Task27_StudentSorting : ITask
    {
        public string Title => "IComparable / IComparer<T> для Student";
        public string Description => "Реализация естественной сортировки студентов по среднему баллу (по убыванию) и альтернативной по имени.";
        public string[] Requirements => new[]
        {
            "Класс Student: Name, AverageGrade.",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.",
            "Продемонстрировать обе сортировки на List<Student>."
        };

        public void Run()
        {
            List<Student> students = new List<Student>
            {
                new Student("Даниил", 4.3),
                new Student("Алексей", 4.8),
                new Student("Виктор", 3.9),
                new Student("Елена", 4.9),
                new Student("Борис", 4.5)
            };
            Console.WriteLine("--- Список ДО сортировки ---");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            students.Sort();
            Console.WriteLine("\n--- После IComparable (по среднему баллу, убывание) ---");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            students.Sort(new ByNameComparer());
            Console.WriteLine("\n--- После IComparer (по имени, алфавит) ---");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}