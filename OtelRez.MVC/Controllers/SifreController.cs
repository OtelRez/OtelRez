using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;

namespace OtelRez.MVC.Controllers
{
    public class SifreController : Controller
    {
        private readonly IUserService _userService;

        public SifreController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SifremiUnuttum(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Message = "Email adresi boş olamaz.";
                return View();
            }

            bool isSuccess = _userService.SendForgotPasswordEmail(email);
            ViewBag.Message = isSuccess ? "Şifreniz mail adresinize gönderildi." : "Kullanıcı bulunamadı.";
            return View();
        }
    }
}
