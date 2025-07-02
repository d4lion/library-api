using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(AplicationDBContext aplicationDBContext) : ControllerBase
    {
        private readonly AplicationDBContext _context = aplicationDBContext;


        [HttpGet]
        public IActionResult GetAll([FromQuery] int? id)
        {
            if (id.HasValue)
            {
            var book = _context.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Where(b => b.Id == id)
                .Select(b => b.ToBookDto());

            if (!book.Any())
            {
                return NotFound(new
                {
                statusCode = 404,
                message = $"El libro con Id: {id} no existe o no fue encontrado",
                traceId = HttpContext.TraceIdentifier
                });
            }

            return Ok(book.FirstOrDefault());
            }

            var books = _context.Book
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Select(b => b.ToBookDto())
            .ToList();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _context.Book
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Where(b => b.Id == id)
            .Select(b => b.ToBookDto());

            if (!book.Any())
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"El libro con Id: {id} no existe o no fue encontrado",
                    traceId = HttpContext.TraceIdentifier
                });
            }

            return Ok(book);
        }

    }
}