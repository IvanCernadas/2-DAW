using Actividad2.Models;
using CernadasFragueiroIvanTarea3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudiantesContext _contexto;

        public EstudiantesController(EstudiantesContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Lista()
        {
            var manager = new EstudiantesManager(_contexto);
            var estudiantes = manager.GetAllEstudiantes();
            return View(estudiantes);
        }

        public IActionResult Detalles(int id) 
        {
            var manager = new EstudiantesManager(_contexto);
            var estudiantes = manager.GetEstudiantesByID(id);

            return View(estudiantes);
        }
    }
}
