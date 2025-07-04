using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Isbn = bookModel.Isbn,
                Title = bookModel.Title,
                Year = bookModel.Year,
                Editorial = bookModel.Editorial,
                Summary = bookModel.Summary,
                Rating = bookModel.Rating,
                PdfLink = bookModel.PdfLink,
                AudioBookLink = bookModel.AudioBookLink,
                Cover = bookModel.Cover,
                DowloadLink = bookModel.DowloadLink,
                Genres = [.. bookModel.Genres.Select(g => g.Name)],
                Authors = [.. bookModel.Authors.Select(g => new AuthorSummaryDto {
                    Name = g.Name,
                    Id = g.Id
                })],

            };
        }
    }
}