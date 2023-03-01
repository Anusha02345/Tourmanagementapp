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
    public class BookingDatasController : ControllerBase
    {
        private readonly TourManagementAppDbContext _context;

        public BookingDatasController(TourManagementAppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookingDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingData>>> GetBookingData()
        {
            return await _context.BookingData.ToListAsync();
        }

        // GET: api/BookingDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingData>> GetBookingData(int id)
        {
            var bookingData = await _context.BookingData.FindAsync(id);

            if (bookingData == null)
            {
                return NotFound();
            }

            return bookingData;
        }

        // PUT: api/BookingDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingData(int id, BookingData bookingData)
        {
            if (id != bookingData.bookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDataExists(id))
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

        // POST: api/BookingDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingData>> PostBookingData(BookingData bookingData)
        {
            _context.BookingData.Add(bookingData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingData", new { id = bookingData.bookingId }, bookingData);
        }

        // DELETE: api/BookingDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingData>> DeleteBookingData(int id)
        {
            var bookingData = await _context.BookingData.FindAsync(id);
            if (bookingData == null)
            {
                return NotFound();
            }

            _context.BookingData.Remove(bookingData);
            await _context.SaveChangesAsync();

            return bookingData;
        }

        private bool BookingDataExists(int id)
        {
            return _context.BookingData.Any(e => e.bookingId == id);
        }
    }
}
