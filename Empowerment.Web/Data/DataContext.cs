using Empowerment.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empowerment.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cortesia> Cortesias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }

    }
}
