using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionID { get; set; }

        [ForeignKey("Curso")]
        public int CursoID { get; set; }

        public Cursos Curso { get; set; } 

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public ICollection<Preguntas> Preguntas { get; set; }
        public ICollection<Intentos> Intentos { get; set; }
    }
    public class EvaluacionDto
    {
        public int EvaluacionID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Intentos { get; set; } 
    }
}
