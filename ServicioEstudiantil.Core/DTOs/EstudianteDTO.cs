namespace ServicioEstudiantil.Core.DTOs
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty; // Unimos nombres y apellidos
        public string CorreoInstitucional { get; set; } = string.Empty;
        public string NombreTitulacion { get; set; } = string.Empty;
    }
}