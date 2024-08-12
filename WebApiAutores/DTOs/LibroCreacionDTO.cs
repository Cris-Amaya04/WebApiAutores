﻿using System.ComponentModel.DataAnnotations;
using WebApiAutores.Validaciones;

namespace WebApiAutores.DTOs
{
    public class LibroCreacionDTO
    {
    

        [Required(ErrorMessage = "El campo {0} es requerido")] //el {0} son valores dinamicos, en este caso 0 es el string Nombre y 1 es el numero 20
        [StringLength(maximumLength: 70, ErrorMessage = "El campo {0} no debe exceder los {1} caracteres")]
        [PrimeraletraMayusculaattribute]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int AutorId { get; set; }
    }
}
