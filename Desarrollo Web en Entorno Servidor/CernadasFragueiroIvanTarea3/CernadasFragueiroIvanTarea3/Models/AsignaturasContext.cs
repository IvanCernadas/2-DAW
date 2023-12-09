using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CernadasFragueiroIvanTarea3.Models
{
    public class AsignaturasContext : DbContext
    {
        public AsignaturasContext(DbContextOptions<AsignaturasContext> options) : base(options) { }
        public DbSet<Asignaturas> Asignaturas { get; set; }
    }
}
