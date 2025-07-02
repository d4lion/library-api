using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author authorModel)
        {
            return new AuthorDto
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                Books = [.. authorModel.Books.Select(b => new BookSummaryDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Rating = b.Rating,
                    PdfLink = b.PdfLink,
                    Cover = b.Cover,
                    DowloadLink = b.DowloadLink,
                    Summary = b.Summary
                })]
            };
        }
    }
}