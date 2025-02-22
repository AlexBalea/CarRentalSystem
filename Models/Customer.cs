using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string DriverLicenseNumber { get; set; }
    }
}
