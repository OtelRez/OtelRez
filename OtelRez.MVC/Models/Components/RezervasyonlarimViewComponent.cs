using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
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
        public async Task<IViewComponentResult> InvokeAsync(int kullaniciId)
        {
            //var rez = rezervasyon.GetAll(p => p.KullaniciId == kullaniciId);

            var rez = await rezervasyon
                .GetAllInclude(
                    p => p.KullaniciId == kullaniciId, // Filtre
                    r => r.Oda // Include edilecek navigation property
                )
                .ToListAsync();

            return View(rez);
        }
    }
}
