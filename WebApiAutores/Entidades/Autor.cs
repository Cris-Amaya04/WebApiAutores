using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{
    public class Autor //: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")] //el {0} son valores dinamicos, en este caso 0 es el string Nombre y 1 es el numero 20
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe exceder los {1} caracteres")]
        [PrimeraletraMayusculaattribute]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }

        public IEnumerable<ComentarioAutores> Comentarios { get; set; }

        //Propiedades para ejemplo de validaciones por modelos
        //El NotMapped es para que no lo agregue a la base de datos, solo para utilizarlo

        //[NotMapped]
        //public int numMayor { get; set; }
        //[NotMapped]
        //public int numMenor { get; set; }

        ////validacion por modelo
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        //{
        //    if(numMenor > numMayor) 
        //    {
        //        //Se puede seguir agregando retornos con el yield
        //        yield return new ValidationResult($"{numMenor} debe ser menor que {numMayor}");
        //    }

        //    if(!string.IsNullOrEmpty(Nombre)) 
        //    {
        //        var primeraLetra = Nombre[0].ToString();
        //        if(primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult($"La primera letra de {Nombre} debe ser en mayúscula"); 
        //        }
        //    }
        //}
    }
}
