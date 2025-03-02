using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class Prediction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required Guid GpId { get; set; }

        public required GrandPrix GrandPrix { get; set; } // Navigation property

        [Required]
        public required Guid PlayerId { get; set; }

        public required User Player { get; set; } // Navigation property

        [Required]
        public PredictionStatus Status { get; set; } // Enum for status
    }

    public enum PredictionStatus
    {
        Success,
        PartialSuccess,
        Fail,
        Pending
    }
}
