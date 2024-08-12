using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Entidades
{
    public class ComentarioAutores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contenido { get; set; }
        public int AutorId { get; set; } //Relacionar comentario con el autor
        public Autor Autor { get; set; }
    }
}
