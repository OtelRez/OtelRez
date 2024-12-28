using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.Components
{
    public class PersonelViewComponent : ViewComponent
    {
        private readonly IManager<Personel> personel;

        public PersonelViewComponent(IManager<Personel> personel)
        {
            this.personel = personel;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pers = personel.GetAllInclude(
                null, // Herhangi bir filtre yok
                p => p.PersonelMeslek, // PersonelMeslek tablosunu dahil et
                p => p.Role // Role tablosunu dahil et
            );

            // IQueryable olduğu için asenkron işleme uygun hale getirin
            var result = pers?.ToList();
            return View(result);
        }
    }
}
