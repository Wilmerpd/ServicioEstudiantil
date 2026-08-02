using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Infrastructure.Data; // O Infrastructure.Persistence según tu namespace

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<Asignatura> Asignaturas => Set<Asignatura>();
    public DbSet<Horario> Horarios => Set<Horario>();
    public DbSet<Titulacion> Titulaciones => Set<Titulacion>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Calificacion> Calificaciones => Set<Calificacion>();
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}