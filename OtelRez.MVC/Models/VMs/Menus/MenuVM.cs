using OtelRez.Entity.Entities.Concrete;

namespace OtelRez.MVC.Models.VMs.Menus
{
    public class MenuVM
    {
        public List<MenuKategori> Kategoriler { get; set; }
        public List<Menu> Menuler { get; set; }
        public int? SeciliKategoriId { get; set; }
    }
}
