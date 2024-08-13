using f1_predictions.Models;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required Guid RoleId { get; set; }

        public required Role Role { get; set; } // Navigation property

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Email { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
