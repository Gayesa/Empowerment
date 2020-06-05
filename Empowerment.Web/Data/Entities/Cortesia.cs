using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Data.Entities
{
    public class Cortesia
    {
        public int Id { get; set; }

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

        [Display(Name = "Teléfono")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Direccion { get; set; }

        /* Medio por el que se entero*/

        [Display(Name = "Web")]
        public bool Web { get; set; }

        [Display(Name = "Instagram")]
        public bool Instagram { get; set; }

        [Display(Name = "Facebook")]
        public bool Facebook { get; set; }

        [Display(Name = "Otro")]
        public bool Otro { get; set; }

        [Display(Name = "Cuál:")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Cual { get; set; }

        [Display(Name = "Fecha Verificación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "Clase de cortesía?")]
        public bool ClaseCortesia { get; set; }

        /* Propiedades de lectura */

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $" {Nombre} {Apellido}";

    }
}
