using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Actividad2.Models
{
    public class EstudiantesManager : IDisposable
    {
        private readonly EstudiantesContext _context;

        public EstudiantesManager(EstudiantesContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudiantes> GetAllEstudiantes()
        {
            var estudiantes = from InstitutoMontecastelo in _context.Estudiantes
                   select InstitutoMontecastelo;
            return estudiantes;
        }

        public Estudiantes GetEstudiantesByID(int id)
        {
            return (Estudiantes)_context.Estudiantes.FirstOrDefault(InstitutoMontecastelo => InstitutoMontecastelo.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
