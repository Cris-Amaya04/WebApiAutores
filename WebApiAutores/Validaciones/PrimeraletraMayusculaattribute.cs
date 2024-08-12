using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Validaciones
{
    public class PrimeraletraMayusculaattribute : ValidationAttribute
    {
        //Validacion que solo quiere confirmar que se agregue la primera letra mayúscula
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {

                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if(primeraLetra == primeraLetra.ToUpper())
            {
                return ValidationResult.Success;
            }
            else
            {
                //Al asignar value, se agrega en el mensaje el valor que tiene value, en este caso, una palabra.
                return new ValidationResult($"La primera letra de {value} debe ser en mayúscula");
            }
        }
    }
}
