using System;
using System.Collections.Generic;
using System.Linq;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public override string ToString()
        {
            return $"Сотрудник: {Name,-10} | Возраст: {Age,2} | Зарплата: {Salary,8:F2} руб. | Отдел: {Department}";
        }
    }

    public class Task33_EmployeeLinq : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "Выполнение LINQ-запросов (OrderByDescending, Take, GroupBy, Average, Where) по списку сотрудников.";
        public string[] Requirements => new[]
        {
            "Класс Employee: Name, Age, Salary, Department.",
            "Список из 10+ сотрудников.",
            "Запросы через LINQ: топ-3 по зарплате (убывание), средняя зарплата по отделу (GroupBy + Average), сотрудники старше 30 (Where).",
            "Вывести результаты."
        };

        public void Run()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Алексей", 28, 95000m, "IT"),
                new Employee("Мария", 32, 120000m, "IT"),
                new Employee("Иван", 25, 60000m, "HR"),
                new Employee("Елена", 41, 110000m, "Management"),
                new Employee("Дмитрий", 35, 85000m, "IT"),
                new Employee("Ольга", 29, 65000m, "HR"),
                new Employee("Сергей", 45, 150000m, "Management"),
                new Employee("Анна", 27, 75000m, "Sales"),
                new Employee("Павел", 38, 90000m, "Sales"),
                new Employee("Кристина", 24, 55000m, "HR"),
                new Employee("Николай", 31, 105000m, "IT")
            };
            Console.WriteLine("--- Полный список сотрудников ---");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
            var top3Salary = employees
                .OrderByDescending(e => e.Salary)
                .Take(3)
                .ToList();
            Console.WriteLine("\n--- 1. Топ-3 сотрудника по зарплате ---");
            foreach (var emp in top3Salary)
            {
                Console.WriteLine(emp);
            }
            var avgSalaryByDept = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                })
                .ToList();
            Console.WriteLine("\n--- 2. Средняя зарплата по отделам ---");
            foreach (var dept in avgSalaryByDept)
            {
                Console.WriteLine($"Отдел: {dept.Department,-12} | Средняя зарплата: {dept.AverageSalary,8:F2} руб.");
            }
            var olderThan30 = employees
                .Where(e => e.Age > 30)
                .ToList();

            Console.WriteLine("\n--- 3. Сотрудники старше 30 лет ---");
            foreach (var emp in olderThan30)
            {
                Console.WriteLine(emp);
            }
        }
    }
}