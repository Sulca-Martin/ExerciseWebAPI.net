using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaVirtual_DataAccessLayer.Data;
using BibliotecaVirtual_DataAccessLayer.Models;

namespace BibliotecaVirtual_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanItemsController : ControllerBase
    {
        private readonly BibliotecaVirtualDbContext _context;

        public LoanItemsController(BibliotecaVirtualDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanItem>>> Get()
        {
            return await _context.loanItems.ToListAsync();
        }

        // GET: api/LoanItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanItem>> GetLoanItem(int id)
        {
            var loanItem = await _context.loanItems.FindAsync(id);

            if (loanItem == null)
            {
                return NotFound("LoanItem not found");
            }

            return loanItem;
        }

        // PUT: api/LoanItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LoanItem loanItem)
        {
            if (id != loanItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanItemExists(id))
                {
                    return NotFound("LoanItem not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanItem>> Post(LoanItem loanItem)
        {
            _context.loanItems.Add(loanItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanItem", new { id = loanItem.Id }, loanItem);
        }

        // DELETE: api/LoanItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loanItem = await _context.loanItems.FindAsync(id);
            if (loanItem == null)
            {
                return NotFound("LoanItem not found");
            }

            _context.loanItems.Remove(loanItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanItemExists(int id)
        {
            return _context.loanItems.Any(e => e.Id == id);
        }
    }
}
