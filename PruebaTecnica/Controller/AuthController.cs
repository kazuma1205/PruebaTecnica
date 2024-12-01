using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Servicios;
namespace PruebaTecnica.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _jwtService;

        public AuthController(AuthServices jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = _jwtService.GenerateToken(request.Password, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Credenciales inválidas" });
        }
    }
}