namespace ServicioEstudiantil.Core.Entities;

public class Profesor
{
    public int Id { get; set; }
    public string Identificacion { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Departamento { get; set; } = string.Empty;
}