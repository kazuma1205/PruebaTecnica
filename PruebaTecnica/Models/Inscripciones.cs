using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionID { get; set; }

        public int UsuarioID { get; set; }

        public int CursoID { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public Usuarios Usuario { get; set; }
        public Cursos Curso { get; set; }
    }
}
