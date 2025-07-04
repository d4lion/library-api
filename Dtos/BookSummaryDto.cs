

namespace api.Dtos
{
    public class BookSummaryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Cover { get; set; } = string.Empty;
        public string DowloadLink { get; set; } = string.Empty;
        public string PdfLink { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;

    }
}
