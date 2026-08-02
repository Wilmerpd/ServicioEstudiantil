using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Entities;
using System.Collections.Generic;

namespace ServicioEstudiantil.Core.Common;

public interface IAppDbContext
{
    DbSet<Estudiante> Estudiantes { get; }
    DbSet<Profesor> Profesores { get; }
    DbSet<Asignatura> Asignaturas { get; }
    DbSet<Horario> Horarios { get; }
    DbSet<Titulacion> Titulaciones { get; }
    DbSet<Matricula> Matriculas { get; }
    DbSet<Calificacion> Calificaciones { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}