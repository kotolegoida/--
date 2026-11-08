using System;
using System.IO;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;
        private bool _disposed = false;

        public FileWriter(string filePath)
        {
            _writer = new StreamWriter(filePath, append: false);
        }

        public void WriteLine(string text)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(FileWriter), "Невозможно выполнить запись в закрытый файл.");
            }
            _writer.WriteLine(text);
            Console.WriteLine($"[Записано]: {text}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _writer?.Dispose();
                    Console.WriteLine("[System]: StreamWriter успешно закрыт, файл освобожден.");
                }
                _disposed = true;
            }
        }
    }

    public class Task31_DisposableFileWriter : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "Реализация интерфейса IDisposable для безопасного управления ресурсами файла с использованием классического using и современной using-декларации.";
        public string[] Requirements => new[]
        {
            "Класс FileWriter с полем StreamWriter.",
            "Реализовать Dispose() (закрыть StreamWriter).",
            "Продемонстрировать использование через using.",
            "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)."
        };

        public void Run()
        {
            string fileName = "test_output.txt";
            Console.WriteLine("--- 1. Демонстрация классического блока using ---");
            {
                FileWriter writer = new FileWriter(fileName);
                try
                {
                    writer.WriteLine("Строка 1: записана через классический using.");
                }
                finally
                {
                    writer?.Dispose();
                }
            }
            Console.WriteLine("\n--- 2. Демонстрация using-декларации (using var) ---");
            {
                using FileWriter writer = new FileWriter(fileName);
                writer.WriteLine("Строка 2: записана с помощью using var.");
            }

            Console.WriteLine("\nФайл успешно записан и закрыт. Ресурсы освобождены.");
        }
    }
}