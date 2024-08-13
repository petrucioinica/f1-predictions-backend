using System.ComponentModel.DataAnnotations;
using YourNamespace.Models;

namespace f1_predictions.Models
{
    public class Prediction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GpId { get; set; }

        public GrandPrix GrandPrix { get; set; } // Navigation property

        [Required]
        public Guid PlayerId { get; set; }

        public User Player { get; set; } // Navigation property

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
