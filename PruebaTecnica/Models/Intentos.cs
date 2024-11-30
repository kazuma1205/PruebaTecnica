using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Intentos
    {
        [Key]
        public int IntentoID { get; set; }
        public int UsuarioID { get; set; }
        public int EvaluacionID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public double? Calificacion { get; set; }

        public Usuarios Usuario { get; set; }
        public Evaluaciones Evaluacion { get; set; }
        public List<RespuestasUsuario> RespuestasUsuario { get; set; }
    }

    public class IntentoDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public double? Calificacion { get; set; }
        public string TituloEvaluacion { get; set; }
    }

}
