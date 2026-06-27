namespace ServicioEstudiantil.Core.Entities
{
    public class Titulacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;

        // Relación: Una titulación tiene muchas asignaturas
        public ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    }
}