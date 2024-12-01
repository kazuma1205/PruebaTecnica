using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }

        public string Email { get; set; }
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public DateTime  FechaRegistro { get; set; }

        public ICollection<UsuarioRoles> UsuarioRoles { get; set; }
        public ICollection<Inscripciones> Inscripciones { get; set; }
        public ICollection<Intentos> Intentos { get; set; }



    }
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
