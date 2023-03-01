using System.ComponentModel.DataAnnotations;

namespace Tour_management_app.Models
{
    public class Destinationlist
    {
        [Key]
        [Required]
        public int DestinationId { get; set; }
        [Required]
        public string DestinationName { get; set; }

    }
}
