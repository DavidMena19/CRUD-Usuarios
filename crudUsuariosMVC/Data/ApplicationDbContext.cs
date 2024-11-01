using crudUsuariosMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace crudUsuariosMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Contacto2> Contacto2 { get; set; }
    }
}
