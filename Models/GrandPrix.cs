using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class GrandPrix
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsFinished { get; set; }

        public DateTime WeekendStart { get; set; }

        public DateTime WeekendEnd { get; set; }

        [Required]
        public Guid SeasonId { get; set; }

        public Season Season { get; set; } // Navigation property

        public int Round { get; set; }

        [Required]
        public string Name { get; set; }

        public string CircuitName { get; set; }

        public string Country { get; set; }
    }
}
