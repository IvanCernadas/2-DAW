using Actividad2.Models;
using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly AsignaturasContext _contexto;

        public AsignaturasController(AsignaturasContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Lista()
        {
            var manager = new AsignaturasManager(_contexto);
            var asignaturas = manager.GetAllAsignaturas();
            return View(asignaturas);
        }

        public IActionResult Detalles(int id) 
        {
            var manager = new AsignaturasManager(_contexto);
            var asignatura = manager.GetAsignaturaByID(id);

            return View(asignatura);
        }
    }
}
