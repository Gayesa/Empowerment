using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Empowerment.Web.Data.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        /* Relaciones */
        public User User { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}

