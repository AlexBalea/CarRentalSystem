using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public int CarID { get; set; }
        public Car Car { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(1, 10000)]
        public decimal TotalCost { get; set; }
    }
}
