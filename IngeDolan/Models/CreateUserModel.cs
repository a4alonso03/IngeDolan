using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IngeDolan.Models
{
    /// <summary>
    /// Provee modelado para los objetos de tipo Usuario
    /// </summary>
    public class CreateUserModel
    {
        [Display(Name = "UserRoles")]
        [Required(ErrorMessage = "El rol es un campo requerido.")]
        public string UserRoles { get; set; }

        [Required(ErrorMessage = "El email campo requerido.")]
        [EmailAddress(ErrorMessage = "Debe ser un email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre es un campo requerido.")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cédula es un campo requerido.")]
        [StringLength(9, ErrorMessage = "La cédula debe ser de {1} dígitos"), MinLength(9, ErrorMessage = "La cédula debe ser de almenos {1} dígitos")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "La cédula debe ser de dígitos")]
        [Display(Name = "Cédula")]
        public int Cedula { get; set; }
    }
}