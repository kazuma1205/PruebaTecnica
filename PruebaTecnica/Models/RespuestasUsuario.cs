using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class RespuestasUsuario
    {
        [Key]
        public int RespuestaUsuarioID { get; set; }
        public Intentos IntentoID { get; set; }
        public Preguntas PreguntaID { get; set; }
        public Respuestas RespuestaID { get; set; }
        public string RespuestaAbierta { get; set; }

    }
}
