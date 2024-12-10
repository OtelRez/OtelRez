using Microsoft.AspNetCore.Mvc;

namespace OtelRez.MVC.Controllers
{
    public class SayfaController : Controller
    {
        public IActionResult Hizmetler()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult Odalar()
        {
            return View();
        }
    }
}
