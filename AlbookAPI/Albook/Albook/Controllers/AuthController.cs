using Albook.Models.DTO;
using Albook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                _logger.LogInformation("Login attempt for user {Username}", request.Username);
                var token = await _authService.AuthenticateAsync(request);
                if (token == null)
                {
                    _logger.LogWarning("Login failed for user {Username}", request.Username);
                    return Unauthorized();
                }

                _logger.LogInformation("Login successful for user {Username}", request.Username);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login for user {Username}", request.Username);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            try
            {
                _logger.LogInformation("Register attempt for user {Username}", request.Username);
                var result = await _authService.RegisterAsync(request);
                if (!result)
                {
                    _logger.LogWarning("Registration failed for user {Username}", request.Username);
                    return BadRequest(new { message = "User registration failed." });
                }

                _logger.LogInformation("Registration successful for user {Username}", request.Username);
                return Ok(new { message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration for user {Username}", request.Username);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
