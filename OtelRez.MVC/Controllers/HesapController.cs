using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs;

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
            var user = kullaniciManager.GetAllInclude(p => p.Mail == girisVM.Mail && p.Sifre == girisVM.Sifre).FirstOrDefault();
            if (user == null)
            {
                notyfService.Error("Email yada Password Hatali.");
                return View(girisVM);
            }

            return RedirectToAction("Index", "Home"); ;
        }
    }
}
