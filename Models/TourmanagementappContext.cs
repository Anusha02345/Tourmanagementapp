using Microsoft.EntityFrameworkCore;
using Tour_management_app.Models;

namespace TourManagementApp.Models
{
    public class TourManagementAppDbContext : DbContext
    {
        public TourManagementAppDbContext(DbContextOptions<TourManagementAppDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<TouristList> TouristLists { get; set; }
        public virtual DbSet<Destinationlist> Destinationlist { get; set; }
        public virtual DbSet<Tourlist> tourlist { get; set; }
        public virtual DbSet<BookingData> BookingData { get; set; }

    }
}
