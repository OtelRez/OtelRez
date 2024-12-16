using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class RezervasyonlarimViewComponent : ViewComponent
    {
        private readonly IManager<Rezervasyon> rezervasyon;

        public RezervasyonlarimViewComponent(IManager<Rezervasyon> rezervasyon)
        {
            this.rezervasyon = rezervasyon;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Kullanici kullanici=new Kullanici();
            // Bu bolum Daha sonra degistirilecek. Gelen Kullanicinin Role'une gore veriler cekilecek
            var rez = rezervasyon.GetAll(kullanici.Id);
            return View(rez);
        }
    }
}
