namespace ServicioEstudiantil.Core.DTOs
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string CorreoInstitucional { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;
        public int TitulacionId { get; set; }
    }
}