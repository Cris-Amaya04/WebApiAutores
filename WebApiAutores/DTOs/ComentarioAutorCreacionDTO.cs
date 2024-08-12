using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOs
{
    public class ComentarioAutorCreacionDTO
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contenido { get; set; }
        public int AutorId { get; set; }
    }
}
