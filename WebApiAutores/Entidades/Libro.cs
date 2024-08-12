using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //el {0} son valores dinamicos, en este caso 0 es el string Nombre y 1 es el numero 20
        [StringLength(maximumLength: 70, ErrorMessage = "El campo {0} no debe exceder los {1} caracteres")]
        [PrimeraletraMayusculaattribute]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; } //referencia a la clase Autor

        public IEnumerable<Comentario> Comentarios { get; set; } //Parte de relacion uno a muchos con la entidad comentario. En este caso 1 libro tiene muchos comentarios
    }
}
