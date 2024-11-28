using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class UsuarioRoles
    {
        [Key]
        public int UsuarioRolID { get; set; }
        public Usuarios UsuarioID { get; set; }
        public Rol RolID { get; set; }

    }
}
