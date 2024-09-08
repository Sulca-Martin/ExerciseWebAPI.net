using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaVirtual_DataAccessLayer.Data;
using BibliotecaVirtual_DataAccessLayer.Models;
using BibliotecaVirtual_WebAPI.Infrastructure.Dto;

namespace BibliotecaVirtual_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BibliotecaVirtualDbContext _context;

        public BooksController(BibliotecaVirtualDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        [Route("/page/{pageNumber}/size/{pageSize}")]
        public async Task<ActionResult> Get(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _context.Books
                .Skip(pageSize * (pageNumber - 1))      //Salteamos una cantidad definida de libros
                .Take(pageSize)     //Toma la cantidad de libros que definimos
                .ToListAsync());
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound("Book not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = bookDto.Title,
                    Synopsis = bookDto.Synopsis,
                    Amount = bookDto.Amount,
                    PublicationDate = bookDto.PublicacionDate,
                    AuthorId = bookDto.AuthorId,
                    CategoryId = bookDto.CategoryId
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBooks", new {id = book.Id} , book);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
