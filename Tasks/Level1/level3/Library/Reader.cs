using System.Collections.Generic;

namespace Main.Tasks.Level3.Library
{
    public class Reader
    {
        public string Name { get; set; } = string.Empty;
        public List<Book> BorrowedBooks { get; set; } = new();

        public Reader(string name)
        {
            Name = name;
        }
    }
}
