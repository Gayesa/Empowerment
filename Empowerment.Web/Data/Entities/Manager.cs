using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Data.Entities
{
    public class Manager
    {
        public int Id { get; set; }

        /* Relación */
        public User User { get; set; }
    }
}
