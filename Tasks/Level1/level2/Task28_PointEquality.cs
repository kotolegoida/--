using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Point);
        }

        public bool Equals(Point? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point? left, Point? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(Point? left, Point? right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    public class Task28_PointEquality : ITask
    {
        public string Title => "Equals / GetHashCode для Point";
        public string Description => "Переопределение методов Equals, GetHashCode и реализация IEquatable<Point> для корректной работы с коллекциями (HashSet).";
        public string[] Requirements => new[]
        {
            "Переопределить Equals(object) и GetHashCode().",
            "Реализовать IEquatable<Point>.",
            "Проверить: две точки с одинаковыми координатами равны.",
            "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count."
        };

        public void Run()
        {
            Point p1 = new Point(5, 10);
            Point p2 = new Point(5, 10);
            Point p3 = new Point(2, 3);
            Console.WriteLine($"p1: {p1}, p2: {p2}, p3: {p3}\n");
            Console.WriteLine("--- Проверка метода Equals ---");
            Console.WriteLine($"p1.Equals(p2) [одинаковые координаты]: {p1.Equals(p2)}");
            Console.WriteLine($"p1.Equals(p3) [разные координаты]: {p1.Equals(p3)}");
            Console.WriteLine($"p1 == p2 (оператор): {p1 == p2}");
            Console.WriteLine("\n--- Проверка в HashSet<Point> ---");
            HashSet<Point> points = new HashSet<Point>();
            points.Add(p1);
            points.Add(p2); // Дубликат по значению (5, 10)
            points.Add(p3);
            Console.WriteLine($"Добавлено точек: 3 (из них две одинаковые: {p1} и {p2})");
            Console.WriteLine($"Количество элементов в HashSet (Count): {points.Count}");
            Console.WriteLine("\nЭлементы в HashSet:");
            foreach (var pt in points)
            {
                Console.WriteLine($"- {pt} (Хеш-код: {pt.GetHashCode()})");
            }
        }
    }
}