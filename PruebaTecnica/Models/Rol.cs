using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string Nombre { get; set; }

        public ICollection<UsuarioRoles> UsuarioRoles { get; set; }
    }
}
