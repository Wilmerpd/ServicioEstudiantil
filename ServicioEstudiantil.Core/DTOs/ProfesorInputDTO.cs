namespace ServicioEstudiantil.Core.DTOs
{
    // Este DTO se usa solo para crear/editar (POST y PUT).
    // El ProfesorDTO normal se sigue usando para leer (GET).
    public class ProfesorInputDTO
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string CorreoContacto { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
    }
}
