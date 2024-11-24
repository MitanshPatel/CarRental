using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserClass user)
        {
            if (!_userService.RegisterUser(user))
            {
                return BadRequest("User already exists");
            }

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _userService.AuthenticateUser(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
