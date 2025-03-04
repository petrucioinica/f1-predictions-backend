using Microsoft.AspNetCore.Mvc;
using f1_predictions.Services;
using f1_predictions.DTOs;
using f1_predictions.DTOs.Auth;

namespace f1_predictions.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseDto("Validation failed", ModelState.ToDictionary(
                    kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                )));
            }

            var response = _authService.ValidateUser(request.Email, request.Password);
            if (response == null)
            {
                return BadRequest(new ErrorResponseDto("Invalid credentials"));
            }



            return Ok(response);
        }
    }
}
