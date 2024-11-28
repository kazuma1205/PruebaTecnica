using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionID { get; set; }
        public Usuarios UsuarioID { get; set; }

        public Cursos CursoID { get; set; }

        public DateTime FechaInscripcion { get; set; }
    }
}
