using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ParkingGarageApi.DTOs;
using ParkingGarageApi.Services.Interfaces;

namespace ParkolohazAPI.Controllers
{
    /// <summary>
    /// Az autentikációs műveleteket kezelő API controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Új felhasználó regisztrációja.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _userService.RegisterAsync(request);
                return Ok(new { message = "Sikeres regisztráció", userId = user.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Felhasználó bejelentkezése.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userService.LoginAsync(request);
                // Itt bővíthető a JWT token generálásával, ha szükséges
                return Ok(new { message = "Sikeres bejelentkezés", userId = user.Id });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
