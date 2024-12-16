using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;
using OtelRez.MVC.Models.VMs.Sayfa;

namespace OtelRez.MVC.Controllers
{
    public class SayfaController(IManager<IletisimeGec> iletisimeGecManager, INotyfService notyfService) : Controller
    {
        public IActionResult Hizmetler()
        {
            return View();
        }

        public IActionResult Rezervasyonlarim()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Iletisim()
        {
            IletisimeGecVM iletisimeGecVM = new IletisimeGecVM();
            return View(iletisimeGecVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Iletisim(IletisimeGecVM iletisimeGecVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(iletisimeGecVM);
            }

            IletisimeGec iletisimeGec = new IletisimeGec();
            iletisimeGec.Adi = iletisimeGecVM.Adi;
            iletisimeGec.Mail= iletisimeGecVM.Mail;
            iletisimeGec.Konu = iletisimeGecVM.Konu;
            iletisimeGec.Mesaj = iletisimeGecVM.Mesaj;

            iletisimeGecManager.Create(iletisimeGec);

            notyfService.Success("İşlem Başarılı");

            return RedirectToAction("Iletisim", "Sayfa");
        }

        public IActionResult Odalar()
        {
            return View();
        }
    }
}
