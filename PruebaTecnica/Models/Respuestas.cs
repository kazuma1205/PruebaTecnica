using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Respuestas
    {
        [Key]
        public int RespuestaID { get; set; }
        public int PreguntaID { get; set; }
        public string Texto { get; set; }
        public bool EsCorrecta { get; set; }

        public Preguntas Pregunta { get; set; }
        public List<RespuestasUsuario> RespuestasUsuario { get; set; }
    }

}
