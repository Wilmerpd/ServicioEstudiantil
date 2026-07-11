namespace ServicioEstudiantil.Core.DTOs
{
    public class HorarioDTO
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Aula { get; set; } = string.Empty;
        public string NombreAsignatura { get; set; } = string.Empty;
    }
}