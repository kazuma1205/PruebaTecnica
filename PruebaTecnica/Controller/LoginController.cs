using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _jwtTokenService;

        public LoginController(TokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Aquí deberías verificar el usuario contra tu base de datos
            if (model.Username == "test" && model.Password == "password")
            {
                var token = _jwtTokenService.GenerateToken(model.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}


public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

