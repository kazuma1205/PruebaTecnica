using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Service;

namespace PruebaTecnica.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuariosServices _usuarioService;

        public LoginController(UsuariosServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorNombreAsync(id);
            return usuario != null ? Ok(usuario) : NotFound();
        }
    }
}


public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

