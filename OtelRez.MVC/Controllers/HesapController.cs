using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using OtelRez.BL.Managers.Abstract;
using OtelRez.BL.Managers.Concrete;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Hesap;
using System.Security.Claims;

namespace OtelRez.MVC.Controllers
{
    [Authorize]
    public class HesapController(IManager<Kullanici> kullaniciManager, IManager<PersonelGiris> personelGirisManager, IManager<Personel> personelManager, INotyfService notyfService) : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();
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
            var user = kullaniciManager.GetAllInclude(p => p.Mail == girisVM.Mail && p.Sifre == girisVM.Sifre, p => p.Role).FirstOrDefault();
            var personel = personelGirisManager.GetAllInclude(p => p.Mail == girisVM.Mail && p.Sifre == girisVM.Sifre).FirstOrDefault();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,girisVM.Mail)
            };

            if (user != null)
            {
                claims.Add(new Claim("userId", user.Id.ToString()));  // userId'yi claim olarak ekliyoruz
            }

            if (personel != null)
            {
                claims.Add(new Claim("personelId", personel.Id.ToString()));  // personelId'yi claim olarak ekliyoruz
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperty = new AuthenticationProperties()
            {
                IsPersistent = girisVM.RememberMe
            };

            var userPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal, authenticationProperty);

            if (user == null)
            {
                if (personel == null)
                {
                    notyfService.Error("Mail ya da şifre hatalı.");
                    return View(girisVM);
                }

                else
                {
                    var personelRoleId = personelManager.GetById(personel.PersonelId);

                    if (personelRoleId.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Admin", new { Area = "Admin" });
                    }

                    else if (personelRoleId.RoleId == 2)
                    {
                        return RedirectToAction("Iletisim", "Sayfa");
                    }

                    else
                    {
                        notyfService.Error("Geçersiz Giriş Bilgisi.");
                        return View(girisVM);
                    }
                }
            }

            return RedirectToAction("Index", "Home"); ;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Kayit()
        {
            KayitVM kayitVM = new KayitVM();
            return View(kayitVM);
        }

        [HttpPost]
        [AllowAnonymous]
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

            notyfService.Success("İşlem Başarılı");

            return RedirectToAction("Giris", "Hesap");
        }
    }
}
