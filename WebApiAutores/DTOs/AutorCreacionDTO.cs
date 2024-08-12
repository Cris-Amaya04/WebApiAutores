using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] //el {0} son valores dinamicos, en este caso 0 es el string Nombre y 1 es el numero 20
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe exceder los {1} caracteres")]
        [PrimeraletraMayusculaattribute]
        public string Nombre { get; set; }
    }
}
