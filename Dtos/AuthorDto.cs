
namespace api.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<BookSummaryDto> Books { get; set; } = [];
    }
}