namespace ServicioEstudiantil.Core.DTOs
{
    public class HorarioInputDTO
    {
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Aula { get; set; } = string.Empty;
        public int AsignaturaId { get; set; }
    }
}
