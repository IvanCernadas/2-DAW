using Actividad2.Models;
using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly ProfesoresContext _contexto;

        public ProfesoresController(ProfesoresContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Lista()
        {
            var manager = new ProfesoresManager(_contexto);
            var profesores = manager.GetAllProfesores();

            return View(profesores);
        }

        public IActionResult Detalles(int id) 
        {
            var manager = new ProfesoresManager(_contexto);
            var profesores = manager.GetProfesoresByID(id);

            return View(profesores);
        }
    }
}
