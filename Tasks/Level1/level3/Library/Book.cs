namespace Main.Tasks.Level3.Library
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}