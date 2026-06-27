namespace ServicioEstudiantil.Core.DTOs
{
    public class AsignaturaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public string NombreTitulacion { get; set; } = string.Empty;
        public string NombreProfesor { get; set; } = string.Empty;
    }
}