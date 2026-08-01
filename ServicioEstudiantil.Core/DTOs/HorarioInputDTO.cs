namespace ServicioEstudiantil.Core.DTOs
{
    public class HorarioInputDTO
    {
        public int Id { get; set; } 
        public string DiaSemana { get; set; } = string.Empty;
        public string Aula { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int AsignaturaId { get; set; }
    }
}