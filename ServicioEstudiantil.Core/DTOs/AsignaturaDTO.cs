namespace ServicioEstudiantil.Core.DTOs;

public class AsignaturaDTO
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int Creditos { get; set; }
    public string Departamento { get; set; } = string.Empty;
}