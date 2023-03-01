using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagementApp.Models;

namespace Tour_management_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristListsController : ControllerBase
    {
        private readonly TourManagementAppDbContext _context;

        public TouristListsController(TourManagementAppDbContext context)
        {
            _context = context;
        }

        // GET: api/TouristLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TouristList>>> GetTouristLists()
        {
            return await _context.TouristLists.ToListAsync();
        }

        // GET: api/TouristLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristList>> GetTouristList(int id)
        {
            var touristList = await _context.TouristLists.FindAsync(id);

            if (touristList == null)
            {
                return NotFound();
            }

            return touristList;
        }

        // PUT: api/TouristLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTouristList(int id, TouristList touristList)
        {
            if (id != touristList.TouristId)
            {
                return BadRequest();
            }

            _context.Entry(touristList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristListExists(id))
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

        // POST: api/TouristLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TouristList>> PostTouristList(TouristList touristList)
        {
            _context.TouristLists.Add(touristList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTouristList", new { id = touristList.TouristId }, touristList);
        }

        // DELETE: api/TouristLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TouristList>> DeleteTouristList(int id)
        {
            var touristList = await _context.TouristLists.FindAsync(id);
            if (touristList == null)
            {
                return NotFound();
            }

            _context.TouristLists.Remove(touristList);
            await _context.SaveChangesAsync();

            return touristList;
        }

        private bool TouristListExists(int id)
        {
            return _context.TouristLists.Any(e => e.TouristId == id);
        }
    }
}
