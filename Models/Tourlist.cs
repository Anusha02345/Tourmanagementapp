using System.ComponentModel.DataAnnotations;

namespace Tour_management_app.Models
{
    public class Tourlist
    {
        [Key]
        [Required]
        public int TourId { get; set; }
        [Required]
        public string TourName { get; set; }
        [Required]
        public int DestinationId { get; set; }
        [Required]
        public string tourdate { get; set; }
        [Required]
        public string tourtime { get; set; }
        [Required]
        public string tourguide { get; set; }
        [Required]
        public double price { get; set; }
    }
}
