using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Actividad2.Models
{
    public class ProfesoresManager : IDisposable
    {
        private readonly ProfesoresContext _context;

        public ProfesoresManager(ProfesoresContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesores> GetAllProfesores()
        {
            var profesores = from InstitutoMontecastelo in _context.Profesores
                   select InstitutoMontecastelo;
            return profesores;
        }

        public Profesores GetProfesoresByID(int id)
        {
            return (Profesores)_context.Profesores.FirstOrDefault(InstitutoMontecastelo => InstitutoMontecastelo.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
