using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(RezOlusturVM rezOlusturVM)
        {
            int kullaniciId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            if (!ModelState.IsValid)
            {
                return View(rezOlusturVM);
            }

            try
            {
                // Giriş yapan kullanıcının ID'sini al
                //var kullaniciId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Rezervasyon nesnesini oluştur
                var rezervasyon = new Rezervasyon
                {
                    Giris = rezOlusturVM.GirisTarihi,
                    Cikis = rezOlusturVM.CikisTarihi
                };
                var tur = odaTurManager.GetAll(p => p.TurAdi == rezOlusturVM.OdaTurAdi).FirstOrDefault();
                int Id = tur.Id;
                // RezervasyonManager üzerinden işlem yap
                bool sonuc = await _rezervasyonManager.RezervasyonOlustur(Id, rezervasyon, kullaniciId);

                if (sonuc)
                {
                    _notyfService.Success("Rezervasyon başarıyla oluşturuldu.");
                    return View(rezOlusturVM);
                }
                else
                {
                    _notyfService.Warning("Seçtiğiniz tarihler için uygun oda bulunamadı.");
                    return View(rezOlusturVM);
                }
            }
            catch (Exception ex)
            {
                _notyfService.Error("Bir hata oluştu");
                return View(rezOlusturVM);
            }

        }
    }
}
