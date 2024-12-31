using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public IActionResult MenuSil(int Id)
        {
            var menu = menuManager.GetById(Id);
            if (menu != null)
            {
                menuManager.Delete(menu);
                notyfService.Success("Ürün silindi");
            }
            else
            {
                notyfService.Error("Ürün bulunamadı");
            }
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MenuGuncelle(int Id)
        {
            var menu = menuManager.GetAllInclude(
                p => p.Id == Id,
                p => p.MenuKategori
            ).FirstOrDefault();

            if (menu == null)
            {
                notyfService.Error("Ürün bulunamadı");
                return RedirectToAction("Index");
            }

            var mevcutKategori = menuKategoriManager.GetAll(p => p.Id == menu.MenuKategoriId)
                .Select(r => r.KategoriAdi)
                .FirstOrDefault();

            var kategoriler = menuKategoriManager.GetAll()
                .Select(r => new SelectListItem
                {
                    Text = r.KategoriAdi,
                    Value = r.Id.ToString()
                }).ToList();

            var menuVM = new MenuVM
            {
                UrunAdi = menu.UrunAdi,
                UrunAciklama = menu.UrunAciklama,
                Fiyat = menu.Fiyat
            };

            ViewBag.MevcutKategoriId = menu.MenuKategoriId;
            ViewBag.MevcutKategori = mevcutKategori;
            ViewBag.Kategoriler = kategoriler;

            return View(menuVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult MenuGuncelle(MenuVM menuVM)
        {
            int menuId = menuVM.Id;
            var menu = menuManager.GetAllInclude(p => p.Id == menuId).FirstOrDefault();

            if (menu == null)
            {
                notyfService.Error("Ürün bulunamadı");
                return View(menuVM);
            }


            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");

                ViewBag.Meslekler = menuKategoriManager.GetAll().Select(r => new SelectListItem
                {
                    Text = r.KategoriAdi,
                    Value = r.Id.ToString()
                }).ToList();

                return View(menuVM);
            }

            menu.UrunAdi = menuVM.UrunAdi;
            menu.UrunAciklama = menuVM.UrunAciklama;
            menu.Fiyat = menuVM.Fiyat;

            menuManager.Update(menu);
            notyfService.Success("Ürün güncellendi");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MenuEkle()
        {
            MenuVM menuVM = new MenuVM();

            ViewBag.Kategoriler = menuKategoriManager.GetAll()
                .Select(r => new SelectListItem
                {
                    Text = r.KategoriAdi,
                    Value = r.Id.ToString()
                }).ToList();

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult MenuEkle(MenuVM menuVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
                ViewBag.Kategoriler = menuKategoriManager.GetAll()
                    .Select(r => new SelectListItem
                    {
                        Text = r.KategoriAdi,
                        Value = r.Id.ToString()
                    }).ToList();
                return View(menuVM);
            }

            Menu menu = new Menu
            {
                UrunAdi = menuVM.UrunAdi,
                UrunAciklama = menuVM.UrunAciklama,
                Fiyat = menuVM.Fiyat,
                MenuKategoriId = menuVM.MenuKategoriId
            };

            menuManager.Create(menu);
            notyfService.Success("Ürün eklendi");
            return RedirectToAction("Index");
        }
    }
}
