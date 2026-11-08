using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class MyStack<T>
    {
        private T[] _array;
        private int _size;
        private const int DefaultCapacity = 4;

        public MyStack()
        {
            _array = new T[DefaultCapacity];
            _size = 0;
        }

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public void Push(T item)
        {
            if (_size == _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2);
            }
            _array[_size++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }
            _size--;
            T item = _array[_size];
            _array[_size] = default(T)!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }
            return _array[_size - 1];
        }
    }
    public class MyQueue<T>
    {
        private T[] _array;
        private int _head;
        private int _tail;
        private int _size;
        private const int DefaultCapacity = 4;

        public MyQueue()
        {
            _array = new T[DefaultCapacity];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public void Enqueue(T item)
        {
            if (_size == _array.Length)
            {
                int newCapacity = _array.Length * 2;
                T[] newArray = new T[newCapacity];
                
                if (_size > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_array, _head, newArray, 0, _size);
                    }
                    else
                    {
                        Array.Copy(_array, _head, newArray, 0, _array.Length - _head);
                        Array.Copy(_array, 0, newArray, _array.Length - _head, _tail);
                    }
                }

                _array = newArray;
                _head = 0;
                _tail = _size;
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _size++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T item = _array[_head];
            _array[_head] = default(T)!;
            _head = (_head + 1) % _array.Length;
            _size--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }
            return _array[_head];
        }
    }
    public class Task19_CustomCollections : ITask
    {
        public string Title => "Свой стек и очередь на массиве";
        public string Description => "Реализация обобщенных MyStack<T> и MyQueue<T> с динамическим расширением массива.";
        public string[] Requirements => new[]
        {
            "Стек: Push, Pop, Peek, Count, IsEmpty.",
            "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty.",
            "При переполнении — расширять внутренний массив (удвоение).",
            "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException."
        };

        public void Run()
        {
            Console.WriteLine("--- Тестирование MyStack<int> ---");
            MyStack<int> stack = new MyStack<int>();
            Console.WriteLine($"Стек пуст? {stack.IsEmpty}");
            
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i * 10);
                Console.WriteLine($"Push: {i * 10}, Count: {stack.Count}");
            }

            Console.WriteLine($"Верхушка стека (Peek): {stack.Peek()}");
            
            while (!stack.IsEmpty)
            {
                Console.WriteLine($"Pop: {stack.Pop()}, Осталось: {stack.Count}");
            }

            Console.WriteLine("\n--- Тестирование MyQueue<string> ---");
            MyQueue<string> queue = new MyQueue<string>();
            
            queue.Enqueue("Первый");
            queue.Enqueue("Второй");
            queue.Enqueue("Третий");
            queue.Enqueue("Четвертый");
            queue.Enqueue("Пятый (триггер расширения)");

            Console.WriteLine($"Элементов в очереди: {queue.Count}");
            Console.WriteLine($"Первый на выход (Peek): {queue.Peek()}");

            while (!queue.IsEmpty)
            {
                Console.WriteLine($"Dequeue: {queue.Dequeue()}, Осталось: {queue.Count}");
            }
        }
    }
}