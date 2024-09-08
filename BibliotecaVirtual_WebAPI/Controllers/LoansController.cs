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
    public class LoansController : ControllerBase
    {
        private readonly BibliotecaVirtualDbContext _context;

        public LoansController(BibliotecaVirtualDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> Get()
        {
            return await _context.Loans.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound("Loan not found");
            }

            return loan;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound("Loan not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> Post([FromBody] CreateLoanDto loanDto)
        {
            var loan = new Loan()
            {
                UserId = loanDto.UserId,
                LoanNumber = Guid.NewGuid().ToString(),
                LoanDate = DateTime.Now,
                ReturnDateId = loanDto.ReturnDateId,
                Description = loanDto.Description,
            };
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            foreach (var item in loanDto.LoanItems)
            {
                var loanItem = new LoanItem
                {
                    LoanId = loan.Id,
                    BookId = item.BookId,
                    Amount = item.Amount,

                };
                _context.Add(loanItem);

            }
            await _context.SaveChangesAsync();

            return Ok(loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound("Loan not found");
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
