using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        [Required, Range(1, 10000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
