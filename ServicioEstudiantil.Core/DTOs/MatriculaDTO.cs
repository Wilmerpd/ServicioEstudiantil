namespace ServicioEstudiantil.Core.DTOs;

public class MatriculaDTO
{
    public int Id { get; set; }
    public int EstudianteId { get; set; }
    public string NombreEstudiante { get; set; } = string.Empty;
    public int AsignaturaId { get; set; }
    public string NombreAsignatura { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public DateTime FechaInscripcion { get; set; }
}