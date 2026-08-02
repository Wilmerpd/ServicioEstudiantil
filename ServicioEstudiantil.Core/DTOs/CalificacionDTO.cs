namespace ServicioEstudiantil.Core.DTOs;

public class CalificacionDTO
{
    public int Id { get; set; }
    public int EstudianteId { get; set; }
    public string NombreEstudiante { get; set; } = string.Empty;
    public int AsignaturaId { get; set; }
    public string NombreAsignatura { get; set; } = string.Empty;
    public decimal Nota { get; set; }
    public string Periodo { get; set; } = string.Empty;
}