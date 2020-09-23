using Empowerment.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empowerment.Web.Models
{
    public class AddInscripcionViewModel : Inscripcion
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Plan")]
        [Range(1, int.MaxValue, ErrorMessage = "-- Seleccionar Plan --")]
        public int TipoPlanId { get; set; }

        public IEnumerable<SelectListItem> Planes { get; set; }

    }
}
