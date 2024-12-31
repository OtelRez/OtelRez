namespace OtelRez.MVC.Areas.Admin.Models.VMs.Admin
{
	public class MenuVM
	{
		public string UrunAdi { get; set; }
		public string? UrunAciklama { get; set; }
		public int Fiyat { get; set; }
		public int MenuKategoriId { get; set; }
	}
}
