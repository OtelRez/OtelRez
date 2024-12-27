using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Internal;
using OtelRez.BL.Managers.Abstract;
using OtelRez.BL.Managers.Concrete;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;
using OtelRez.MVC.Models.VMs.Rezervasyon;
using System.Security.Claims;

namespace OtelRez.MVC.Controllers
{
    [Authorize]
    public class RezervasyonOlusturController : Controller
    {
        private readonly RezervasyonManager _rezervasyonManager;
        private readonly INotyfService _notyfService;
        private readonly IManager<OdaTur> odaTurManager;

        public RezervasyonOlusturController(INotyfService notyfService)
        {
            _rezervasyonManager = new RezervasyonManager();
            _notyfService = notyfService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            RezOlusturVM rezOlusturVM = new RezOlusturVM();
            var odaTurleri = await _rezervasyonManager.GetOdaTurleriAsync();
            ViewBag.OdaTurleri = odaTurleri.Select(t => new SelectListItem
            {
                Text = t.TurAdi,
                Value = t.Id.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(RezOlusturVM rezOlusturVM)
        {
            int kullaniciId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            
            if (!ModelState.IsValid)
            {
                var odaTurleri = await _rezervasyonManager.GetOdaTurleriAsync();
                ViewBag.OdaTurleri = odaTurleri.Select(t => new SelectListItem
                {
                    Text = t.TurAdi,
                    Value = t.Id.ToString()
                }).ToList();

                return RedirectToAction("Index", "RezervasyonOlustur");

            }

            try
            {
                var rezervasyon = new Rezervasyon
                {
                    Giris = rezOlusturVM.GirisTarihi,
                    Cikis = rezOlusturVM.CikisTarihi
                };

                bool sonuc = await _rezervasyonManager.RezervasyonOlustur(rezOlusturVM.OdaTurId, rezervasyon, kullaniciId);

                if (sonuc)
                {
                    _notyfService.Success("Rezervasyon başarıyla oluşturuldu.");
                    return RedirectToAction("Index", "RezervasyonOlustur");

                }
                else
                {
                    var odaTurleriReload = await _rezervasyonManager.GetOdaTurleriAsync();
                    ViewBag.OdaTurleri = odaTurleriReload.Select(t => new SelectListItem
                    {
                        Text = t.TurAdi,
                        Value = t.Id.ToString()
                    }).ToList();

                    _notyfService.Warning("Seçtiğiniz tarihler için uygun oda bulunamadı.");
                    return RedirectToAction("Index", "RezervasyonOlustur");
                }
            }

            catch (Exception ex)
            {
                _notyfService.Error("Bir hata oluştu");
                var odaTurleriReload = await _rezervasyonManager.GetOdaTurleriAsync();
                ViewBag.OdaTurleri = odaTurleriReload.Select(t => new SelectListItem
                {
                    Text = t.TurAdi,
                    Value = t.Id.ToString()
                }).ToList();

                return RedirectToAction("Index", "RezervasyonOlustur");
            }

        }
    }
}
