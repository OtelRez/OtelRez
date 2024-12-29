using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;

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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult PersonelGuncelle(PersonelVM personelVM)
        {
            int personelId = personelVM.Id;
            var personel = personelManager.GetAllInclude(p => p.Id == personelId).FirstOrDefault();

            if (personel == null)
            {
                notyfService.Error("Kullanıcı bulunamadı.");
                return RedirectToAction("Index", "Admin");
            }

            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(personelVM);
                
            }

            ViewBag.Roller = roleManager.GetAll().Select(r => new SelectListItem
            {
                Text = r.RoleAdi,
                Value = r.Id.ToString()
            }).ToList();

            ViewBag.Meslekler = meslekManager.GetAll().Select(r => new SelectListItem
            {
                Text = r.Meslek,
                Value = r.Id.ToString()
            }).ToList();

            personel.Adi = personelVM.Adi;
            personel.Soyadi = personelVM.Soyadi;
            personel.IzinHakki = personelVM.IzinHakki;
            personel.Maas = personelVM.Maas;
            personel.RoleId = personelVM.RoleId;
            personel.PersonelMeslekId = personelVM.PersonelMeslekId;

            personelManager.Update(personel);

            notyfService.Success("İşlem Başarılı");
            return RedirectToAction("Personeller");
        }
    }
}