using System;
using System.Collections.Generic;

namespace Main.Tasks.Level3.Library
{
    public class LibraryService
    {
        public List<Book> Books { get; } = new();
        public List<Reader> Readers { get; } = new();
        public const int MaxBooksPerReader = 3;

        public void AddBook(Book book) => Books.Add(book);
        public void AddReader(Reader reader) => Readers.Add(reader);

        public void BorrowBook(Reader reader, Book book)
        {
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Книга уже выдана другому читателю.");
            }

            if (reader.BorrowedBooks.Count >= MaxBooksPerReader)
            {
                throw new InvalidOperationException($"Превышен лимит книг (максимум {MaxBooksPerReader}).");
            }

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }

        public void ReturnBook(Reader reader, Book book)
        {
            if (!reader.BorrowedBooks.Contains(book))
            {
                throw new ArgumentException("У этого читателя нет данной книги.");
            }

            reader.BorrowedBooks.Remove(book);
            book.IsAvailable = true;
        }
    }
}