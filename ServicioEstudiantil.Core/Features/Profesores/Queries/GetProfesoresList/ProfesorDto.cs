namespace ServicioEstudiantil.Core.DTOs;

public class ProfesorDTO
{
    public int Id { get; set; }
    public string Identificacion { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Departamento { get; set; } = string.Empty;
}