using Microsoft.AspNetCore.Mvc;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    public class MesajController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
