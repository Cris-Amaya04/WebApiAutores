using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOs
{
    public class ComentarioAutorDTO
    {
        public int AutorId { get; set; }

        public string Contenido { get; set; }
    }
}
