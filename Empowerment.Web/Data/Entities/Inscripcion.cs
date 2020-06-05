using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empowerment.Web.Data.Entities
{
    public class Inscripcion
    {
        public int Id { get; set; }

        [Display(Name = "Vigencia")]
        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Vigencia { get; set; }

        [Display(Name = "Fecha Inicio Plan")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Finalización Plan")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Renovación Plan")]
        [MaxLength(5, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Renovacion { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no debe tener más de {1} carácteres.")]
        public string Observacion { get; set; }

        [Display(Name = "Pago Efectivo?")]
        public bool Efectivo { get; set; }

        [Display(Name = "Pago Tarjeta?")]
        public bool Tarjeta { get; set; }

        [Display(Name = "Debe?")]
        public bool Deuda { get; set; }

        //TODO: Delete those lines
        //Mirar lo del pdf

        /* Relaciones */

        public Plan Plan { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
    }
}
