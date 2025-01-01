using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class RezOdaTurDetayViewComponent : Controller
    {
        private readonly IManager<OdaTur> odaTur;

        public RezOdaTurDetayViewComponent(IManager<OdaTur> odaTur)
        {
            this.odaTur = odaTur;
        }
        public async Task<IViewComponentResult> InvokeAsync(int odaTurId)
        {
            var tur = odaTur.GetById(odaTurId);  

            return View(tur);
        }
    }
}
