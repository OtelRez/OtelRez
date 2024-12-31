using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Areas.Admin.Models.Components
{
	public class MenuViewComponent : ViewComponent
	{
		private readonly IManager<Menu> menu;

		public MenuViewComponent(IManager<Menu> menu)
		{
			this.menu = menu;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var temp = menu.GetAllInclude(
				null, // Herhangi bir filtre yok
				p => p.MenuKategori // MenuKategori tablosunu dahil et
			);

			// IQueryable olduğu için asenkron işleme uygun hale getirin
			var result = temp?.ToList();
			return View(result);
		}
	}
}
