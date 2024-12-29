﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;
using System.Globalization;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IManager<Personel> personelManager;
        private readonly IManager<Role> roleManager;
        private readonly IManager<PersonelMeslek> meslekManager;
        private readonly INotyfService notyfService;
        private readonly AppDbContext _dbContext;

        public AdminController(IManager<Personel> personelManager, IManager<Role> roleManager, IManager<PersonelMeslek> meslekManager, INotyfService notyfService, AppDbContext dbContext)
        {
            this.personelManager = personelManager;
            this.roleManager = roleManager;
            this.meslekManager = meslekManager;
            this.notyfService = notyfService;
            this._dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Rezervasyonlar(int ay = 0, int yil = 0)
        {
            if (ay == 0) ay = DateTime.Now.Month;
            if (yil == 0) yil = DateTime.Now.Year;

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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Personeller()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult PersonelGuncelle(int Id)
        {
            // Kullanıcıyı al
            var user = personelManager.GetAllInclude(
                p => p.Id == Id,
                p => p.PersonelMeslek,
                p => p.Role
            ).FirstOrDefault();

            if (user == null)
            {
                notyfService.Error("Kullanıcı bulunamadı.");
                return RedirectToAction("Index");
            }

            #region Personel Rol
            // Mevcut rolü al
            var mevcutRol = roleManager
                .GetAll(r => r.Id == user.RoleId)
                .Select(r => r.RoleAdi)
                .FirstOrDefault();

            // Tüm roller
            var roller = roleManager
                .GetAll()
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.RoleAdi
                })
                .ToList();
            #endregion

            #region Personel Meslek
            // Mevcut rolü al
            var mevcutMeslek = meslekManager
                .GetAll(r => r.Id == user.PersonelMeslekId)
                .Select(r => r.Meslek)
                .FirstOrDefault();

            // Tüm roller
            var meslekler = meslekManager
                .GetAll()
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Meslek
                })
                .ToList();
            #endregion
           
            var personelVM = new PersonelVM
            {
                Adi = user.Adi,
                Soyadi = user.Soyadi,
                IzinHakki = user.IzinHakki,
                Maas = user.Maas
            };

            ViewBag.MevcutRol = mevcutRol;
            ViewBag.Roller = roller;

            ViewBag.MevcutMeslek = mevcutMeslek;
            ViewBag.Meslekler = meslekler;

            return View(personelVM);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult PersonelGuncelle(PersonelVM personelVM)
        //{
        //}
    }
}
