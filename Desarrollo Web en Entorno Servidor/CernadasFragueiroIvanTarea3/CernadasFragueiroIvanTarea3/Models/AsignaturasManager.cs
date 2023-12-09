using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Actividad2.Models
{
    public class AsignaturasManager : IDisposable
    {
        private readonly AsignaturasContext _context;

        public AsignaturasManager(AsignaturasContext context)
        {
            _context = context;
        }

        public IEnumerable<Asignaturas> GetAllAsignaturas()
        {
            var asignaturas = from InstitutoMontecastelo in _context.Asignaturas
                   select InstitutoMontecastelo;
            return asignaturas;
        }

        public Asignaturas GetAsignaturaByID(int id)
        {
            return (Asignaturas)_context.Asignaturas.FirstOrDefault(InstitutoMontecastelo => InstitutoMontecastelo.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
