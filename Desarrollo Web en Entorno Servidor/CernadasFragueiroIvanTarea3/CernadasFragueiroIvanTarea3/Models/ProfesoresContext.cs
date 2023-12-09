using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CernadasFragueiroIvanTarea3.Models
{
    public class ProfesoresContext : DbContext
    {
        public ProfesoresContext(DbContextOptions<ProfesoresContext> options) : base(options) { }
        public DbSet<Profesores> Profesores { get; set; }
    }
}
