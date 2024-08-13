using System.ComponentModel.DataAnnotations;

namespace f1_predictions.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; } // Primary Key of type UUID

        [Required]
        public required string Name { get; set; } // Role name (e.g., Admin, GameMaster, Player)
    }
}