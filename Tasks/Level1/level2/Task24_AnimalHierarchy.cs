using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level2
{
    public abstract class Animal
    {
        public string Name { get; set; }

        protected Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            return $"Животное: {GetType().Name}, Имя: {Name}";
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} (Собака) говорит: Гав-гав!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} (Кошка) говорит: Мяу-мяу!");
        }
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} (Птица) говорит: Чирик-чирик!");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} летит в небе!");
        }
    }

    public class Task24_AnimalHierarchy : ITask
    {
        public string Title => "ООП: Animal → Dog/Cat/Bird";
        public string Description => "Построение иерархии классов животных с использованием абстрактного класса и полиморфизма.";
        public string[] Requirements => new[]
        {
            "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
            "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
            "Bird дополнительно имеет метод Fly().",
            "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле."
        };

        public void Run()
        {
            List<Animal> animals = new List<Animal>
            {
                (Animal)new Dog("Бобик"),
                (Animal)new Cat("Мурка"),
                (Animal)new Bird("Чижик")
            };

            Console.WriteLine("--- Демонстрация полиморфизма (цикл MakeSound и ToString) ---");
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.MakeSound();

                if (animal is Bird bird)
                {
                    bird.Fly();
                }

                Console.WriteLine();
            }
        }
    }
}