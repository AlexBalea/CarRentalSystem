using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Please select a booking.")]
        public int BookingID { get; set; }

        [ForeignKey("BookingID")]
        public Booking? Booking { get; set; } 

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 10000, ErrorMessage = "Amount must be between 1 and 10000.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; } = "Cash"; 

        [Required(ErrorMessage = "Payment Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
