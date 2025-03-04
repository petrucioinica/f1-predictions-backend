using f1_predictions.Models;

namespace f1_predictions.DTOs.Auth
{
    public record LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public Role Role { get; set; }
        public string AccessToken { get; set; }

        public LoginResponseDto(Guid id, string username, string email, string? profilePicture, Role role, string accessToken)
        {
            Id = id;
            Username = username;
            Email = email;
            ProfilePicture = profilePicture ?? string.Empty;
            Role = role;
            AccessToken = accessToken;


        }
    }
}
