using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Sayfa;

namespace OtelRez.MVC.Controllers
{
    public class SayfaController(IManager<IletisimeGec> iletisimeGecManager, INotyfService notyfService) : Controller
    {
        public IActionResult Hizmetler()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Iletisim()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Iletisim(IletisimeGecVM iletisimeGecVM)
        {
            return
        }

        public IActionResult Odalar()
        {
            return View();
        }
    }
}
