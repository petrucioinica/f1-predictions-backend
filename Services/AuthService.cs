using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using f1_predictions.Models;
using f1_predictions.Data;
using f1_predictions.Core;
using Microsoft.EntityFrameworkCore;
using f1_predictions.DTOs.Auth;


namespace f1_predictions.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly F1DbContext _context;

        public AuthService(IConfiguration config, F1DbContext context)
        {
            _config = config;
            _context = context;
        }

        public string GenerateJwtToken(User user)
        {
            var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET") ?? _config["JwtSettings:Secret"];
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public LoginResponseDto? ValidateUser(string email, string password)
        {
            var hashedPass =Helpers.HashPassword(password);
            var foundUser =  _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email && u.Password == hashedPass);
            if (foundUser != null)
            {
                var token = GenerateJwtToken(foundUser);
                if(token != null)
                {
                    return new LoginResponseDto
                    (
                        id: foundUser.Id,
                        username: foundUser.Username,
                        email: foundUser.Email,
                        profilePicture: foundUser.ProfilePicture ?? string.Empty,
                        role: foundUser.Role,
                        accessToken: token
                    );
                }
               
            }
            return null;
        }
    }
}
