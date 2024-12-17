﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;
using OtelRez.MVC.Models.VMs.Sayfa;

namespace OtelRez.MVC.Controllers
{
    public class SayfaController(IManager<IletisimeGec> iletisimeGecManager, IManager<Kullanici> kullaniciManager, INotyfService notyfService) : Controller
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

            else
            {
                IletisimeGec iletisimeGec = new IletisimeGec();
                iletisimeGec.Adi = iletisimeGecVM.Adi;
                iletisimeGec.Mail = iletisimeGecVM.Mail;
                iletisimeGec.Konu = iletisimeGecVM.Konu;
                iletisimeGec.Mesaj = iletisimeGecVM.Mesaj;

                iletisimeGecManager.Create(iletisimeGec);

                notyfService.Success("İşlem Başarılı");

                return RedirectToAction("Iletisim", "Sayfa");
            }
        }

        public IActionResult Odalar()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Ayarlar()
        {
            AyarlarVM ayarlarVM = new AyarlarVM();
            return View(ayarlarVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Ayarlar(AyarlarVM ayarlarVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(ayarlarVM);
            }

            int temp = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var kullanici = kullaniciManager.GetAll(p => p.Id == temp).FirstOrDefault();
            
            if(kullanici != null)
            {
                kullanici.Adi = ayarlarVM.Adi;
                kullanici.Soyadi = ayarlarVM.Soyadi;
                kullanici.Mail = ayarlarVM.Mail;
                kullanici.Tel = ayarlarVM.Tel;

                kullaniciManager.Update(kullanici);

                notyfService.Success("İşlem Başarılı");

                return RedirectToAction("Ayarlar", "Sayfa");
            }
            notyfService.Error("Kullanıcı bulunamadı");
            return View(ayarlarVM);
        }

    }
}
