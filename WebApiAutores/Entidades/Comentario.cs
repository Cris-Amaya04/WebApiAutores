using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contenido { get; set; }
        public int LibroId { get; set; } //Relacionar comentario con el libro
        public Libro Libro { get; set; } //Atributo de navegacion, parte de relacion uno a muchos, 1 libro tiene muchos comentarios 
    }
}
