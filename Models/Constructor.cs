using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class Constructor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Points { get; set; }

        [Required]
        public Guid SeasonId { get; set; }

        public Season Season { get; set; } // Navigation property

        public ICollection<Driver> Drivers { get; set; } = new List<Driver>(); // Navigation property
    }
}