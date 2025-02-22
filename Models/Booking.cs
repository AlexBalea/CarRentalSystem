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
        
        public Car Car { get; set; }

        [Required(ErrorMessage = "Please select a Customer.")]
        public int CustomerID { get; set; }  

        [ForeignKey("CustomerID")]
        
        public Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [CustomValidation(typeof(Booking), "ValidateStartDate")]
        public DateTime StartDate { get; set; }

        public static ValidationResult ValidateStartDate(DateTime startDate, ValidationContext context)
        {
            return (startDate < DateTime.Today)
                ? new ValidationResult("Start Date must be in the future.")
                : ValidationResult.Success;
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [CustomValidation(typeof(Booking), "ValidateEndDate")]
        public DateTime EndDate { get; set; }

        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)
        {
            var instance = (Booking)context.ObjectInstance;
            return (endDate <= instance.StartDate)
                ? new ValidationResult("End Date must be after the Start Date.")
                : ValidationResult.Success;
        }

        [Range(1, 10000)]
        public decimal TotalCost { get; set; }
    }
}
