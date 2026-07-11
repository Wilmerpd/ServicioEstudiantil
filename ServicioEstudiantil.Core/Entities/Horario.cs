namespace ServicioEstudiantil.Core.Entities
{
    public class Horario
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty; // Ej: Lunes, Martes
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Aula { get; set; } = string.Empty;

        // Relación: Un horario le pertenece a una asignatura
        public int AsignaturaId { get; set; }
        public Asignatura? Asignatura { get; set; }
    }
}