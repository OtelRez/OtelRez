using Microsoft.AspNetCore.Mvc;
using OtelRez.DAL.DbContexts;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RezervasyonController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index(int ay = 0, int yil = 0)
        {
            if (ay == 0) ay = DateTime.Now.Month;
            if (yil == 0) yil = DateTime.Now.Year;

            ViewBag.Ay = ay;
            ViewBag.Yil = yil;

            var odalar = _dbContext.Odalar.ToList();
            var rezervasyonlar = _dbContext.Rezervasyonlar
                .Where(r => r.Giris.Year == yil && r.Giris.Month == ay || r.Cikis.Year == yil && r.Cikis.Month == ay)
                .ToList();

            var gunSayisi = DateTime.DaysInMonth(yil, ay);

            var tablo = odalar.Select(oda => new RezTabloVM
            {
                OdaNumarasi = oda.OdaNumarasi,
                Gunler = Enumerable.Range(1, gunSayisi).Select(gun =>
                {
                    var tarih = new DateOnly(yil, ay, gun);
                    return rezervasyonlar.Any(r => r.OdaId == oda.Id && r.Giris <= tarih && r.Cikis > tarih);
                }).ToArray()
            }).ToList();

            return View(tablo);
        }
    }
}
