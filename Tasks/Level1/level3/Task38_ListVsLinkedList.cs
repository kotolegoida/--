using System;
using System.Collections.Generic;
using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task38_ListVsLinkedList : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "Сравнение производительности вставки в середину List<T> и LinkedList<T>.";
        public string[] Requirements => new[]
        {
            "Создать List<int> и LinkedList<int> по 100 000 элементов.",
            "Вставить 1000 элементов в середину каждой коллекции.",
            "Замерить время через Stopwatch.",
            "Вывести оба времени и объяснить результат."
        };

        public void Run()
        {
            int count = 100000;
            int insertions = 1000;

            var list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            var linkedList = new LinkedList<int>();
            for (int i = 0; i < count; i++)
            {
                linkedList.AddLast(i);
            }

            var sw = Stopwatch.StartNew();
            int middleIndex = list.Count / 2;
            for (int i = 0; i < insertions; i++)
            {
                list.Insert(middleIndex, -1);
            }
            sw.Stop();
            long listTime = sw.ElapsedMilliseconds;

            sw.Restart();
            var node = linkedList.First;
            for (int i = 0; i < count / 2 && node != null; i++)
            {
                node = node.Next;
            }

            if (node != null)
            {
                for (int i = 0; i < insertions; i++)
                {
                    linkedList.AddBefore(node, -1);
                }
            }
            sw.Stop();
            long linkedListTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"Количество элементов: {count}");
            Console.WriteLine($"Количество вставок: {insertions}\n");
            Console.WriteLine($"Время List<T>: {listTime} мс");
            Console.WriteLine($"Время LinkedList<T>: {linkedListTime} мс\n");
            
            Console.WriteLine("Результат:");
            Console.WriteLine("LinkedList<T> быстрее при вставке, так как меняет только ссылки узлов. List<T> вынужден каждый раз сдвигать половину массива в памяти.");
        }
    }
}