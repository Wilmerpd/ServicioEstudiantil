namespace ServicioEstudiantil.Core.DTOs
{
    public class ProfesorDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string CorreoContacto { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
    }
}