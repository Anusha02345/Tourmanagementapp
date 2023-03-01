using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TourManagementApp.Models
{
    public class TouristList
    {
        [Key]
        [Required]
        public int TouristId { get; set; }
        [Required]
        public string TouristName { get;set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
    
    

    