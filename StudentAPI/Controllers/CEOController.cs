using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CEOController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CEOController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CEO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CEO>>> GetCeos()
        {
            return await _context.Ceos.ToListAsync();
        }

        // GET: api/CEO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CEO>> GetCEO(int id)
        {
            var cEO = await _context.Ceos.FindAsync(id);

            if (cEO == null)
            {
                return NotFound();
            }

            return cEO;
        }

        // PUT: api/CEO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCEO(int id, CEO cEO)
        {
            if (id != cEO.Id)
            {
                return BadRequest();
            }

            _context.Entry(cEO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CEOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CEO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CEO>> PostCEO(CEO cEO)
        {
            _context.Ceos.Add(cEO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCEO", new { id = cEO.Id }, cEO);
        }

        // DELETE: api/CEO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCEO(int id)
        {
            var cEO = await _context.Ceos.FindAsync(id);
            if (cEO == null)
            {
                return NotFound();
            }

            _context.Ceos.Remove(cEO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CEOExists(int id)
        {
            return _context.Ceos.Any(e => e.Id == id);
        }
    }
}
