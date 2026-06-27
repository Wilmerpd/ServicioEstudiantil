namespace ServicioEstudiantil.Core.Entities
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string CorreoContacto { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;

        // Relación: Un profesor imparte muchas asignaturas
        public ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    }
}