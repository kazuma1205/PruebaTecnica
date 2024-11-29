using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //Entitys
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Evaluaciones> Evaluaciones { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Intentos> Intentos { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }

        public DbSet<RespuestasUsuario> RespuestasUsuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<UsuarioRoles> UsuarioRoles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


    }
}
