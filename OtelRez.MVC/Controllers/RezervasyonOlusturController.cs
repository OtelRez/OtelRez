using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Concrete;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;
using OtelRez.MVC.Models.VMs.Rezervasyon;

namespace OtelRez.MVC.Controllers
{
    public class RezervasyonOlusturController : Controller
    {
        private readonly RezervasyonManager _rezervasyonManager;
        private readonly INotyfService _notyfService;

        public RezervasyonOlusturController(INotyfService notyfService)
        {
            _rezervasyonManager = new RezervasyonManager();
            _notyfService = notyfService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            RezOlusturVM rezVm = new RezOlusturVM();
            return View(rezVm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(RezOlusturVM rezOlusturVM)
        {
            if (!ModelState.IsValid) // ViewModel doğrulama
            {
                _notyfService.Warning("Lütfen gerekli alanları doldurunuz.");
                return View(rezOlusturVM);
            }

            try
            {
                var rezervasyon = new Rezervasyon
                {
                    Giris = rezOlusturVM.GirisTarihi,
                    Cikis = rezOlusturVM.CikisTarihi,
                    CreateTime = DateTime.Now
                };

                // Oda türüne göre Id al
                int turId = await _rezervasyonManager.GetTurIdByAdi(rezOlusturVM.OdaTurAdi);

                bool sonuc = await _rezervasyonManager.RezervasyonOlustur(turId, rezervasyon);

                if (!sonuc)
                {
                    _notyfService.Warning("Uygun oda bulunamadı, lütfen başka bir tarih seçiniz.");
                    return View(rezOlusturVM);
                }

                _notyfService.Success($"Rezervasyon başarıyla oluşturuldu. Toplam Tutar: {rezervasyon.ToplamTutar} TL");
                return RedirectToAction("RezervasyonOlustur"); // Aynı sayfaya geri dön
            }
            catch (Exception ex)
            {
                _notyfService.Error($"Bir hata oluştu: {ex.Message}");
                return View(model);
            }

        }
    }
}
