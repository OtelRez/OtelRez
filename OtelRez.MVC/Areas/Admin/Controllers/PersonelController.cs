using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.Repositories.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonelController(IManager<Personel> personelManager, IManager<Role> roleManager, IManager<PersonelMeslek> meslekManager, 
        IRepository<Personel> personelRepository, INotyfService notyfService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelSil(int Id)
        {
            var personel = personelRepository.GetById(Id);

            if (personel != null)
            {
                personelRepository.Delete(personel);
                notyfService.Success("Personel silindi");
            }
            else
            {
                notyfService.Error("Personel bulunamadı");
            }
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult PersonelGuncelle(int Id)
        {
            // Kullanıcıyı al
            var personel = personelManager.GetAllInclude(
                p => p.Id == Id,
                p => p.PersonelMeslek,
                p => p.Role
            ).FirstOrDefault();

            if (personel == null)
            {
                notyfService.Error("Kullanıcı bulunamadı.");
                return RedirectToAction("Index");
            }

            #region Personel Rol
            // Mevcut rolü al
            var mevcutRol = roleManager
                .GetAll(r => r.Id == personel.RoleId)
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
                .GetAll(r => r.Id == personel.PersonelMeslekId)
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
                Adi = personel.Adi,
                Soyadi = personel.Soyadi,
                IzinHakki = personel.IzinHakki,
                Maas = personel.Maas
            };

            ViewBag.MevcutRolId = personel.RoleId;
            ViewBag.MevcutRol = mevcutRol;
            ViewBag.Roller = roller;

            ViewBag.MevcutMeslekId = personel.PersonelMeslekId;
            ViewBag.MevcutMeslek = mevcutMeslek;
            ViewBag.Meslekler = meslekler;

            return View(personelVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult PersonelGuncelle(PersonelVM personelVM)
        {
            int personelId = personelVM.Id;
            var personel = personelManager.GetAllInclude(p => p.Id == personelId).FirstOrDefault();

            if (personel == null)
            {
                notyfService.Error("Kullanıcı bulunamadı.");
                return View(personelVM);
            }

            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");

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

                return View(personelVM);
            }

            personel.Adi = personelVM.Adi;
            personel.Soyadi = personelVM.Soyadi;
            personel.IzinHakki = personelVM.IzinHakki;
            personel.Maas = personelVM.Maas;

            personel.PersonelMeslekId = personelVM.PersonelMeslekId;

            if (personelVM.RoleId == 0)
            {
                personel.RoleId = null;
            }
            else
            {
                personel.RoleId = personelVM.RoleId;
            }

            personelManager.Update(personel);
            notyfService.Success("İşlem Başarılı");
            return RedirectToAction("Index", "Personel");
        }

        [HttpGet]
        [Authorize]
        public IActionResult PersonelEkle()
        {
            PersonelVM personelVM = new PersonelVM();

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
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult PersonelEkle(PersonelVM personelVM)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Düzeltilmesi gereken yerler var");
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
                return View(personelVM);
            }

            Personel personel = new Personel
            {
                Adi = personelVM.Adi,
                Soyadi = personelVM.Soyadi,
                IzinHakki = personelVM.IzinHakki,
                Maas = personelVM.Maas,
                PersonelMeslekId = personelVM.PersonelMeslekId
            };
            if (personel.RoleId == 0)
            {
                personelVM.RoleId = null;
            }
            else
            {
                personelVM.RoleId = personel.RoleId;
            }

            personelManager.Create(personel);
            notyfService.Success("İşlem Başarılı");
            return RedirectToAction("Index","Personel");
        }

    }
}
