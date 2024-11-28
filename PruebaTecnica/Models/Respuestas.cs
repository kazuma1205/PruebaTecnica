using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Respuestas
    {
        [Key]
        public int RespuestaID { get; set; }

        public Preguntas PreguntaID { get; set; }

        public string Texto { get; set; }

        public bool EsCorrecta { get; set; }
        public ICollection<RespuestasUsuario> RespuestasUsuario { get; set; }

    }
}
