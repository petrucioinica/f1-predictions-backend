using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class SeasonParticipation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required Guid ParticipantId { get; set; }

        public required User Participant { get; set; } // Navigation property

        [Required]
        public required Guid SeasonId { get; set; }

        public required Season Season { get; set; } // Navigation property

        public double Points { get; set; }
    }
}
