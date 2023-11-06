using System;

namespace biblioteca
{
    public class Libro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public Guid AutorId { get; set; }
    }

    public class AutorDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
    }
}
