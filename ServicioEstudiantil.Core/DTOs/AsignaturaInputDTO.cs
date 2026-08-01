namespace ServicioEstudiantil.Core.DTOs
{
    public class AsignaturaInputDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int TitulacionId { get; set; }
        public int ProfesorId { get; set; }
    }
}
