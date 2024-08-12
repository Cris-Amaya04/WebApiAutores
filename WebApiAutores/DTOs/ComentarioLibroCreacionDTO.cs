using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOs
{
    public class ComentarioLibroCreacionDTO
    {
        //Si se establece en la ruta un campo o atributo, en este caso LibroId, no es necesario colocarlo en el DTO
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contenido { get; set; }
    }
}
