using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level2
{
    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Круг (Радиус: {Radius}, Площадь: {Area():F2}, Периметр: {Perimeter():F2})";
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area()
        {
            return Width * Height;
        }

        public double Perimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Прямоугольник (Ширина: {Width}, Высота: {Height}, Площадь: {Area():F2}, Периметр: {Perimeter():F2})";
        }
    }

    public class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Area()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return $"Треугольник (Стороны: {A}, {B}, {C}, Площадь: {Area():F2}, Периметр: {Perimeter():F2})";
        }
    }

    public class Task25_ShapeSorting : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Реализация интерфейса IShape для геометрических фигур, расчет площади/периметра и сортировка коллекции по площади.";
        public string[] Requirements => new[]
        {
            "IShape с методами Area() и Perimeter().",
            "Классы Circle, Rectangle, Triangle — реализуют IShape.",
            "Создать List<IShape> из 5+ фигур.",
            "Отсортировать по площади (через List.Sort с лямбдой).",
            "Вывести фигуры с площадями до и после сортировки."
        };

        public void Run()
        {

            List<IShape> shapes = new List<IShape>
            {
                new Circle(5),               
                new Rectangle(4, 6),         
                new Triangle(3, 4, 5),       
                new Circle(2),               
                new Rectangle(10, 2),        
                new Triangle(6, 8, 10)       
            };
            Console.WriteLine("--- Фигуры ДО сортировки ---");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
            shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));
            Console.WriteLine("\n--- Фигуры ПОСЛЕ сортировки по площади (возрастание) ---");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}