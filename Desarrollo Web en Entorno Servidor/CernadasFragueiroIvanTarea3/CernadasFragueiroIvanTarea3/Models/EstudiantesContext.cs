using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CernadasFragueiroIvanTarea3.Models
{
    public class EstudiantesContext : DbContext
    {
        public EstudiantesContext(DbContextOptions<EstudiantesContext> options) : base(options) { }
        public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}
