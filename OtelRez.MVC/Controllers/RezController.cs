using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OtelRez.DAL.Repositories.Abstract;
using OtelRez.DAL.Repositories.Concrete;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Controllers
{
    public class RezController : Controller
    {
        private readonly IRepository<Rezervasyon> _repository;
        private readonly INotyfService _notyfService;

        public RezController(IRepository<Rezervasyon> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RezIptal(int id)
        {
            // Repository kullanılarak rezervasyon bulunuyor
            try
            {
                var rezervasyon = _repository.GetById(id);

                if (rezervasyon != null)
                {
                    // Rezervasyonu siliyoruz
                    _repository.Delete(rezervasyon);
                    _notyfService.Success("Rezervasyon iptal edildi.");
                }
                else
                {
                    _notyfService.Error("Rezervasyon bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                _notyfService.Error(ex.Message);
            }

            return RedirectToAction("Rezervasyonlarim","Sayfa"); // Listeleme sayfasına yönlendirme
        }
    }
}
