using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagementApp.Models;
using Tour_management_app.Models;

namespace Tour_management_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationlistsController : ControllerBase
    {
        private readonly TourManagementAppDbContext _context;

        public DestinationlistsController(TourManagementAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Destinationlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destinationlist>>> GetDestinationlist()
        {
            return await _context.Destinationlist.ToListAsync();
        }

        // GET: api/Destinationlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destinationlist>> GetDestinationlist(int id)
        {
            var destinationlist = await _context.Destinationlist.FindAsync(id);

            if (destinationlist == null)
            {
                return NotFound();
            }

            return destinationlist;
        }

        // PUT: api/Destinationlists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinationlist(int id, Destinationlist destinationlist)
        {
            if (id != destinationlist.DestinationId)
            {
                return BadRequest();
            }

            _context.Entry(destinationlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationlistExists(id))
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

        // POST: api/Destinationlists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Destinationlist>> PostDestinationlist(Destinationlist destinationlist)
        {
            _context.Destinationlist.Add(destinationlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinationlist", new { id = destinationlist.DestinationId }, destinationlist);
        }

        // DELETE: api/Destinationlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Destinationlist>> DeleteDestinationlist(int id)
        {
            var destinationlist = await _context.Destinationlist.FindAsync(id);
            if (destinationlist == null)
            {
                return NotFound();
            }

            _context.Destinationlist.Remove(destinationlist);
            await _context.SaveChangesAsync();

            return destinationlist;
        }

        private bool DestinationlistExists(int id)
        {
            return _context.Destinationlist.Any(e => e.DestinationId == id);
        }
    }
}
