using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;

namespace OtelRez.MVC.Controllers
{
    public class HesapController(IManager<Kullanici> kullaniciManager, INotyfService notyfService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Giris()
        {
            GirisVM girisVM = new GirisVM();
            return View(girisVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Giris(GirisVM girisVM)
        {
            var user = kullaniciManager.GetAllInclude(p => p.Mail == girisVM.Mail && p.Sifre == girisVM.Sifre).FirstOrDefault(); ;
            if (user == null)
            {
                notyfService.Error("Mail ya da şifre hatalı.");
                return View(girisVM);
            }

            return RedirectToAction("Index", "Home"); ;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Kayit()
        {
            KayitVM kayitVM = new KayitVM();
            return View(kayitVM);
        }

        [HttpPost]
        public IActionResult Kayit(KayitVM kayitVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(kayitVM);
            }
            Kullanici kullanici = new Kullanici();
            kullanici.Adi = kayitVM.Adi;
            kullanici.Soyadi = kayitVM.Soyadi;
            kullanici.Mail = kayitVM.Mail;
            kullanici.Tel = kayitVM.Tel;
            kullanici.DogumTarihi = kayitVM.DogumTarihi;
            kullanici.Sifre = kayitVM.Sifre;

            kullaniciManager.Create(kullanici);
            notyfService.Success("Islem Basarili");

            return RedirectToAction("Giris", "Hesap");
        }
    }
}
