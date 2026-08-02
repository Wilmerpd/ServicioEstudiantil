namespace ServicioEstudiantil.Core.Entities;

public class Matricula
{
    public int Id { get; set; }

    public int EstudianteId { get; set; }
    public Estudiante? Estudiante { get; set; }

    public int AsignaturaId { get; set; }
    public Asignatura? Asignatura { get; set; }

    public string Periodo { get; set; } = string.Empty; // Ej: "2026-1"
    public DateTime FechaInscripcion { get; set; } = DateTime.UtcNow;
}