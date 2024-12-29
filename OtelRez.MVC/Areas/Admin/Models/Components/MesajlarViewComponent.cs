using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Areas.Admin.Models.Components
{
    public class MesajlarViewComponent : ViewComponent
    {
        private readonly IManager<IletisimeGec> iletisimeGec;

        public MesajlarViewComponent(IManager<IletisimeGec> iletisimeGec)
        {
            this.iletisimeGec = iletisimeGec;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mesajlar = iletisimeGec.GetAll();
            return View(mesajlar);
        }
    }
}
