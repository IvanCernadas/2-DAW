using Microsoft.AspNetCore.Mvc;

namespace CernadasFragueiroIvanTarea3.Controllers
{
    public class MiCurriculum : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
