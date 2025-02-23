using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Please select a Car.")]
        public int CarID { get; set; }

        [ForeignKey("CarID")]
        public Car? Car { get; set; } // Allow null, EF will populate it later

        [Required(ErrorMessage = "Please select a Customer.")]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; } // Allow null, EF will populate it later

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [CustomValidation(typeof(Booking), "ValidateEndDate")]
        public DateTime EndDate { get; set; }

        [Range(1, 10000)]
        public decimal TotalCost { get; set; }

        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)
        {
            var booking = (Booking)context.ObjectInstance;

            if (endDate <= booking.StartDate)
            {
                return new ValidationResult("End Date must be later than Start Date.");
            }

            return ValidationResult.Success;
        }
    }
}
