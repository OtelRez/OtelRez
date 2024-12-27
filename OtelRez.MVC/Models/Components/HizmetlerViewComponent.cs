using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class HizmetlerViewComponent : ViewComponent
    {
        private readonly IManager<Hizmetler> hizmetler;

        public HizmetlerViewComponent(IManager<Hizmetler> hizmetler)
        {
            this.hizmetler = hizmetler;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hizmetlers = hizmetler.GetAll();
            return View(hizmetlers);
        }
        
    }
}
