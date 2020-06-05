using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Data.Entities
{
    public class Seguimiento
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Inscripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "Comentarios")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no debe tener más de {1} carácteres.")]
        public string Comentarios { get; set; }

        /* Relaciones */

        public Inscripcion Inscripcion { get; set; }

    }                          
}
