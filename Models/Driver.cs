using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class Driver
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DriverCode { get; set; }

        public int DriverNumber { get; set; }

        [Required]
        public Guid ConstructorId { get; set; }

        public Constructor Constructor { get; set; } // Navigation property

        [Required]
        public Guid SeasonId { get; set; }

        public Season Season { get; set; } // Navigation property
    }
}
