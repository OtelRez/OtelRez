using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController(IManager<Menu> menuManager,
        IManager<MenuKategori> menuKategoriManager, INotyfService notyfService) : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MenuGuncelle(int Id)
        {
            var menu = menuManager.GetAllInclude(
                p => p.Id == Id,
                p => p.MenuKategoriId
            ).FirstOrDefault();

            if (menu == null)
            {
                notyfService.Error("Ürün bulunamadı");
            }

            var mevcutKategori = menuKategoriManager.GetAll(p => p.Id == menu.MenuKategoriId)
                .Select(p => p.KategoriAdi)
                .FirstOrDefault();

            var kategoriler = menuKategoriManager.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.KategoriAdi
                }).ToList();

            var menuVM = new MenuVM
            {
                UrunAdi = menu.UrunAdi,
                UrunAciklama = menu.UrunAciklama,
                Fiyat = menu.Fiyat,

            };

            ViewBag.MevcutKategoriId = menu.MenuKategoriId;
            ViewBag.MevcutKategori = mevcutKategori;
            ViewBag.Kategoriler = kategoriler;

            return View(menuVM);
        }
    }
}
