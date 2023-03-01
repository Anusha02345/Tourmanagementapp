using System.ComponentModel.DataAnnotations;

namespace Tour_management_app.Models
{
    public class BookingData
    {
        [Key]
        [Required]
        public int bookingId { get; set; }
        [Required]
        public int touristId { get; set; }
        [Required]
        public int tourId { get; set; }
        [Required]
        public string bookingdate { get; set; }
    }
}
