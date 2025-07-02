

namespace api.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Rating { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string DowloadLink { get; set; } = string.Empty;
        public string PdfLink { get; set; } = string.Empty;
        public string AudioBookLink { get; set; } = string.Empty;

        public List<AuthorSummaryDto> Authors { get; set; } = [];
        public List<string> Genres { get; set; } = [];

    }
}