using System.ComponentModel.DataAnnotations;
using YourNamespace.Models;

namespace f1_predictions.Models
{
    public class SeasonParticipation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ParticipantId { get; set; }

        public User Participant { get; set; } // Navigation property

        [Required]
        public Guid SeasonId { get; set; }

        public Season Season { get; set; } // Navigation property

        public double Points { get; set; }
    }
}
