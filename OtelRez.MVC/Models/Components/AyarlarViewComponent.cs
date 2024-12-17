using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class AyarlarViewComponent : ViewComponent
    {
        private readonly IManager<Kullanici> kullanici;

        public AyarlarViewComponent(IManager<Kullanici> kullanici)
        {
            this.kullanici = kullanici;
        }
        public async Task<IViewComponentResult> InvokeAsync(int kullaniciId)
        {
            var kullanicilar = kullanici.GetAll(p => p.Id == kullaniciId);
            return View(kullanicilar);
        }
    }
}
