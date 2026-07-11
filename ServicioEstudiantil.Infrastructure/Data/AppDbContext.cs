using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Entidades base
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Titulacion> Titulaciones { get; set; }

        // LAS DOS ENTIDADES NUEVAS QUE AGREGAMOS HOY
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
    }
}