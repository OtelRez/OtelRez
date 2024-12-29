using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
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

            // RoleId kontrolü
            if (user.RoleId == null)
            {
                notyfService.Error("Kullanıcının rol bilgisi eksik.");
                return RedirectToAction("Index");
            }

            // Mevcut rolü al
            var mevcutRol = roleManager
                .GetAll(r => r.Id == user.RoleId)
                .Select(r => r.RoleAdi)
                .FirstOrDefault();

            if (mevcutRol == null)
            {
                notyfService.Error("Kullanıcının rolü bulunamadı.");
                return RedirectToAction("Index");
            }

            // Tüm roller
            var roller = roleManager
                .GetAll()
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.RoleAdi
                })
                .ToList();

            if (roller == null || !roller.Any())
            {
                notyfService.Error("Roller bulunamadı.");
                return RedirectToAction("Index");
            }

            // Kullanıcı bilgilerini VM'ye aktar
            var personelVM = new PersonelVM
            {
                Adi = user.Adi,
                Soyadi = user.Soyadi,
                IzinHakki = user.IzinHakki,
                Maas = user.Maas
            };

            // Role ve diğer veriler ViewBag'e aktarılıyor
            ViewBag.MevcutRol = mevcutRol;
            ViewBag.Roller = roller;

            return View(personelVM);
        }
    }
}
