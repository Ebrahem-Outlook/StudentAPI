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
    public class HeadManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeadManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HeadManager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeadManager>>> GetHeadManagers()
        {
            return await _context.HeadManagers.ToListAsync();
        }

        // GET: api/HeadManager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeadManager>> GetHeadManager(int id)
        {
            var headManager = await _context.HeadManagers.FindAsync(id);

            if (headManager == null)
            {
                return NotFound();
            }

            return headManager;
        }

        // PUT: api/HeadManager/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeadManager(int id, HeadManager headManager)
        {
            if (id != headManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(headManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadManagerExists(id))
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

        // POST: api/HeadManager
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeadManager>> PostHeadManager(HeadManager headManager)
        {
            _context.HeadManagers.Add(headManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeadManager", new { id = headManager.Id }, headManager);
        }

        // DELETE: api/HeadManager/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeadManager(int id)
        {
            var headManager = await _context.HeadManagers.FindAsync(id);
            if (headManager == null)
            {
                return NotFound();
            }

            _context.HeadManagers.Remove(headManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeadManagerExists(int id)
        {
            return _context.HeadManagers.Any(e => e.Id == id);
        }
    }
}
