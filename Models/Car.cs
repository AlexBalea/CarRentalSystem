using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(1, 1000)]
        public decimal DailyRate { get; set; }

        public bool Available { get; set; }
    }
}
