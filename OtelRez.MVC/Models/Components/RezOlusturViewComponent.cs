using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class RezOlusturViewComponent : ViewComponent
    {
        private readonly IManager<Rezervasyon> rezManager;

        public RezOlusturViewComponent(IManager<Rezervasyon> rezManager)
        {
            this.rezManager = rezManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var turs = rezManager.GetAll();
            return View(turs);
        }
    }
}
