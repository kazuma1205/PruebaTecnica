using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Preguntas
    {
        [Key]
        public int PreguntaID { get; set; }
        public Evaluaciones EvaluacionID { get; set; }
        public string Texto { get; set; }
        public string Tipo { get; set; }
        public ICollection<Respuestas> Respuestas { get; set; }
        public ICollection<RespuestasUsuario> RespuestasUsuario { get; set; }



    }
}
