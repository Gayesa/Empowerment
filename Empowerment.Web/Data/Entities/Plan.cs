using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Data.Entities
{
    public class Plan
    {
        public int Id { get; set; }

        [Display(Name = "Plan")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Categoria { get; set; }

        [Display(Name = "Abreviatura")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        public string Sigla { get; set; }

        [Display(Name = "Sesiones")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sesiones { get; set; }

        [Display(Name = "Costo")]
        [MaxLength(12, ErrorMessage = "El campo {0} no debe tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Costo { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(150, ErrorMessage = "El Campo {0} no debe tener más de {1} carácteres.")]
        public string Descripcion { get; set; }


        /* Propiedades de Lectura */

        public string CategoriaSesiones => $"{Categoria} - {Sesiones}";
        public string SiglaSesiones => $"{Sigla} - {Sesiones}";

        /* Relaciones */

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
