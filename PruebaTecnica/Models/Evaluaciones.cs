using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionID { get; set; }

        public Cursos CursoID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ICollection<Preguntas> Preguntas { get; set; }
        public ICollection<Intentos> Intentos { get; set; }



    }
}
