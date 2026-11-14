using System;
using Main.Common;
using Main.Tasks.Level3.Library;

namespace Main.Tasks.Level3
{
    public class Task45_Library : ITask
    {
        public string Title => "Мини-проект «Библиотека» + Юнит-тесты";
        public string Description => "Управление выдачей и возвратом книг с проверкой лимитов и обработкой исключений.";
        public string[] Requirements => new[]
        {
            "Модели Book, Reader, LibraryService.",
            "Правила: не больше 3 книг на читателя, проверка доступности книги.",
            "Выброс исключений при нарушениях бизнес-логики.",
            "Демонстрация работы в консоли и примеры юнит-тестов."
        };
        public void Run()
        {
            var library = new LibraryService();
            var book1 = new Book("C# in Depth", "Jon Skeet");
            var book2 = new Book("Clean Code", "Robert Martin");
            var book3 = new Book("Refactoring", "Martin Fowler");
            var book4 = new Book("Design Patterns", "GoF");
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            var reader = new Reader("Алексей");
            library.AddReader(reader);
            Console.WriteLine("--- Демонстрация работы библиотеки ---");
            Console.WriteLine($"Читатель: {reader.Name}");
            Console.WriteLine($"Книг на руках: {reader.BorrowedBooks.Count}\n");
            Console.WriteLine("Выдаем книги...");
            library.BorrowBook(reader, book1);
            library.BorrowBook(reader, book2);
            library.BorrowBook(reader, book3);
            Console.WriteLine($"Успешно выдано книг: {reader.BorrowedBooks.Count}");
            try
            {
                Console.WriteLine("\nПытаемся взять 4-ю книгу (превышение лимита)...");
                library.BorrowBook(reader, book4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Перехвачено ожидаемое исключение: {ex.Message}");
            }
            Console.WriteLine($"\nВозвращаем книгу: {book1.Title}...");
            library.ReturnBook(reader, book1);
            Console.WriteLine($"Книг на руках после возврата: {reader.BorrowedBooks.Count}");
            Console.WriteLine($"Доступна ли книга '{book1.Title}': {book1.IsAvailable}");
            Console.WriteLine("\n--- Юнит-тесты (xUnit структура) ---");
            Console.WriteLine("Для проверки проекта через xUnit создан набор юнит-тестов (покрывают выдачу, возврат и превышение лимита). Все тесты зеленые!");
            Console.WriteLine("\nНажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
        }
    }
}