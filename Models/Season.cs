using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class Season
    {
        [Key]
        public Guid Id { get; set; }

        public int Year { get; set; }

        public bool HasEnded { get; set; }

        public bool HasStarted { get; set; }

        public ICollection<Constructor> Constructors { get; set; } = new List<Constructor>(); // Navigation property
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>(); // Navigation property
        public ICollection<GrandPrix> GrandPrixes { get; set; } = new List<GrandPrix>(); // Navigation property
    }
}
