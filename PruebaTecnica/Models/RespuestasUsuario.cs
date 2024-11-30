using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class RespuestasUsuario
    {
        [Key]
        public int RespuestaUsuarioID { get; set; }
        public int IntentoID { get; set; }
        public int PreguntaID { get; set; }
        public int? RespuestaID { get; set; }
        public string RespuestaAbierta { get; set; }

        public Intentos Intento { get; set; }
        public Preguntas Pregunta { get; set; }
        public Respuestas Respuesta { get; set; }
    }

}
