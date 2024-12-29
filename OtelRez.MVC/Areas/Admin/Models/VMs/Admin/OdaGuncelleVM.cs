namespace OtelRez.MVC.Areas.Admin.Models.VMs.Admin
{
    public class OdaGuncelleVM
    {
        public int Id { get; set; }
        public string OdaAdi { get; set; }
        public int Fiyat { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile PhotoPathFile { get; set; }
    }
}
