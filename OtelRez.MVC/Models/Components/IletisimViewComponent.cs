using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class IletisimViewComponent : ViewComponent
    {
        private readonly IManager<Iletisim> iletisim;

        public IletisimViewComponent(IManager<Iletisim> iletisim)
        {
            this.iletisim = iletisim;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Bu bolum Daha sonra degistirilecek. Gelen Kullanicinin Role'une gore veriler cekilecek
            var iletisimler = iletisim.GetAll();
            return View(iletisimler);
        }
    }
}
