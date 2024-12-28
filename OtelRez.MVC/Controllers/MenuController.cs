using Microsoft.AspNetCore.Mvc;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Models.VMs.Menus;

namespace OtelRez.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? kategoriId)
        {
            var model = new MenuVM
            {
                Kategoriler = _context.MenuKategoriler.OrderBy(k => k.Id).ToList(),
                Menuler = kategoriId.HasValue
                    ? _context.Menuler.Where(m => m.MenuKategoriId == kategoriId).ToList()
                    : new List<Menu>(), // Varsayılan olarak boş liste
                SeciliKategoriId = kategoriId
            };

            return View(model);
        }
    }
}
