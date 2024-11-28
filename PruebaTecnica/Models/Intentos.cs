using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Intentos
    {
        [Key]
        public int IntentoID { get; set; }
        public Usuarios UsuarioID { get; set; }
        public Evaluaciones EvaluacionID { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public float Calificacion { get; set; }
        public ICollection<RespuestasUsuario> RespuestasUsuario { get; set; }


    }
}
