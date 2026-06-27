namespace ServicioEstudiantil.Core.Entities
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; }

        // Claves Foráneas
        public int TitulacionId { get; set; }
        public Titulacion? Titulacion { get; set; }

        public int ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
    }
}