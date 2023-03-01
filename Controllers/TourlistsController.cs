using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagementApp.Models;
using Tour_management_app.Models;

namespace Tourmanagementapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourlistsController : ControllerBase
    {
        private readonly TourManagementAppDbContext _context;

        public TourlistsController(TourManagementAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tourlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tourlist>>> Gettourlist()
        {
            return await _context.tourlist.ToListAsync();
        }

        // GET: api/Tourlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tourlist>> GetTourlist(int id)
        {
            var tourlist = await _context.tourlist.FindAsync(id);

            if (tourlist == null)
            {
                return NotFound();
            }

            return tourlist;
        }

        // PUT: api/Tourlists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourlist(int id, Tourlist tourlist)
        {
            if (id != tourlist.TourId)
            {
                return BadRequest();
            }

            _context.Entry(tourlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourlistExists(id))
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

        // POST: api/Tourlists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tourlist>> PostTourlist(Tourlist tourlist)
        {
            _context.tourlist.Add(tourlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourlist", new { id = tourlist.TourId }, tourlist);
        }

        // DELETE: api/Tourlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tourlist>> DeleteTourlist(int id)
        {
            var tourlist = await _context.tourlist.FindAsync(id);
            if (tourlist == null)
            {
                return NotFound();
            }

            _context.tourlist.Remove(tourlist);
            await _context.SaveChangesAsync();

            return tourlist;
        }

        private bool TourlistExists(int id)
        {
            return _context.tourlist.Any(e => e.TourId == id);
        }
    }
}
