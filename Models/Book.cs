
namespace api.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public decimal Rating { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty; 
         public ICollection<Author> Authors { get; set; } = [];
        public ICollection<Genre> Genres { get; set; } = [];
        public string Summary { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string DowloadLink { get; set; } = string.Empty;
        public string PdfLink { get; set; } = string.Empty;
        public string AudioBookLink { get; set; } = string.Empty;

    }
}
