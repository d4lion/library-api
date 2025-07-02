using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController(AplicationDBContext aplicationDBContext) : ControllerBase
    {
        private readonly AplicationDBContext _context = aplicationDBContext;

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _context.Author
                .Include(a => a.Books)
                .ToList();

            var authorsDto = authors.Select(a => a.ToAuthorDto());

            return Ok(authorsDto);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetById([FromRoute] int authorId)
        {
            var author = _context.Author
            .Include(a => a.Books)
            .Where(a => a.Id == authorId)
            .Select(a => a.ToAuthorDto());

            if (!author.Any())
            {
                return NotFound(new
                {
                    status = 404,
                    message = "El autor no existe",
                    traceId = HttpContext.TraceIdentifier

                });
            }

            return Ok(author);
        }

    }
}