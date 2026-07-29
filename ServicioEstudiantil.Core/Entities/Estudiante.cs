namespace ServicioEstudiantil.Core.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string CorreoInstitucional { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;

        // Relación: El estudiante pertenece a una titulación
        public int TitulacionId { get; set; }
        public Titulacion? Titulacion { get; set; }
    }
}