using System.Xml.Linq;

namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<BookImage> Images { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
    }
}
