using Empowerment.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Models
{
    public class AddUserViewModel : User
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [EmailAddress]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} debe contener entre {2} y {1} carácteres.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Password")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} debe contener entre {2} y {1} carácteres.")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

    }
}
