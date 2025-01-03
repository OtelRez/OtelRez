﻿using AspNetCoreHero.ToastNotification.Abstractions;
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

            var odaTur = odaTurManager.GetById(rezOlusturVM.OdaTurId);
            if (odaTur != null)
            {
                rezOlusturVM.OdaTurAdi = odaTur.TurAdi;
                rezOlusturVM.OdaTurPhotoPath = odaTur.PhotoPath;
            }
            return RedirectToAction("OdemeYap", rezOlusturVM);
        }

        [HttpGet]
        public IActionResult OdemeYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OdemeYap(RezOlusturVM rezOlusturVM)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Warning("Lütfen tüm bilgileri doldurun.");
                return RedirectToAction("Index");
            }

            rezOlusturVM.ToplamTutar = _rezervasyonManager.ToplamTutar(
                rezOlusturVM.OdaTurId,
                rezOlusturVM.GirisTarihi,
                rezOlusturVM.CikisTarihi
            );

            var odaTur = await _rezervasyonManager.GetOdaTurByIdAsync(rezOlusturVM.OdaTurId);
            rezOlusturVM.OdaTurAdi = odaTur?.TurAdi;
            rezOlusturVM.OdaTurPhotoPath = odaTur?.PhotoPath;
            rezOlusturVM.Wifi = odaTur?.WiFi;
            rezOlusturVM.OdaServisi = odaTur?.OdaServisi;
            rezOlusturVM.Balkon = odaTur?.Balkon;
            rezOlusturVM.Jakuzi = odaTur?.Jakuzi;
            rezOlusturVM.Minibar = odaTur?.Minibar;

            return View(rezOlusturVM);
        }

        [HttpPost]
        public async Task<IActionResult> Tamamla(RezOlusturVM rezOlusturVM)
        {
            int kullaniciId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);

            try
            {
                var rezervasyon = new Rezervasyon
                {
                    Giris = rezOlusturVM.GirisTarihi,
                    Cikis = rezOlusturVM.CikisTarihi
                };

                int toplamTutar = _rezervasyonManager.ToplamTutar(rezOlusturVM.OdaTurId, rezOlusturVM.GirisTarihi, rezOlusturVM.CikisTarihi);
                ViewBag.ToplamTutar = toplamTutar;

                bool sonuc = await _rezervasyonManager.RezervasyonOlustur(rezOlusturVM.OdaTurId, rezervasyon, kullaniciId);

                if (sonuc)
                {
                    _notyfService.Success("Rezervasyon başarıyla oluşturuldu.");
                    return RedirectToAction("Rezervasyonlarim", "Sayfa");
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