using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Preguntas
    {
        [Key]
        public int PreguntaID { get; set; }
        [ForeignKey("Evaluacion")]

        public int EvaluacionID { get; set; }
        public Evaluaciones Evaluacion { get; set; }

        public string Texto { get; set; }
        public string Tipo { get; set; }
        public ICollection<Respuestas> Respuestas { get; set; }
        public ICollection<RespuestasUsuario> RespuestasUsuario { get; set; }



    }
}

