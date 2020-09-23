using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Empowerment.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Fecha de Inscripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "Tipo Documento")]
        [MaxLength(25, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoDocumento { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Documento { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Direccion { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Lugar de Nacimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string LugarNacimiento { get; set; }

        [Display(Name = "Edad")]
        [MaxLength(10, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Edad { get; set; }

        [Display(Name = "Género")]
        [MaxLength(15, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Genero { get; set; }

        [Display(Name = "Peso")]
        [MaxLength(10, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Peso { get; set; }

        [Display(Name = "Estatura")]
        [MaxLength(15, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Estatura { get; set; }

        [Display(Name = "Grado Escolaridad")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string GradoEscolaridad { get; set; }

        [Display(Name = "Institución Educativa")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string InstitucionEducativa { get; set; }

        /* Actividades */

        [Display(Name = "Cultural")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Cultural { get; set; }

        [Display(Name = "Deportiva")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Deportiva { get; set; }

        [Display(Name = "Artistica")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Artistica { get; set; }

        [Display(Name = "Recreativa")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Recreativa { get; set; }

        /* Datos Acudiente */

        [Display(Name = "Nombre Responsable")]
        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombreAcudiente { get; set; }

        [Display(Name = "Ocupación")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string OcupacionAcudiente { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TelefonoAcudiente { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

     

        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://TDB.azurewebsites.net{ImageUrl.Substring(1)}";
    }

}

