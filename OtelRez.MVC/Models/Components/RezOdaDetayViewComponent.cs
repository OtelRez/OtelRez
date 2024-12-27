using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class RezOdaDetayViewComponent : ViewComponent
    {
        private readonly IManager<OdaTur> turler;

        public RezOdaDetayViewComponent(IManager<OdaTur> turler)
        {
            this.turler = turler;
        }
        public async Task<IViewComponentResult> InvokeAsync(int odaTurId)
        {
            var turs = turler.GetAll(p => p.Id == odaTurId);
            return View(turs);
        }
    }
}
