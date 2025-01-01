using System.ComponentModel.DataAnnotations;

namespace OtelRez.MVC.Models.VMs.Rezervasyon
{
    public class RezOlusturVM
    {
        [Required(ErrorMessage = "Giriş tarihini boş bıraktınız")]
        public DateTime GirisTarihi { get; set; }

        [Required(ErrorMessage = "Çıkış tarihini boş bıraktınız")]
        public DateTime CikisTarihi { get; set; }

        [Required(ErrorMessage = "Oda türü seçmediniz")]
        public int OdaTurId { get; set; }
        public int ToplamTutar { get; set; }
        public string? OdaTurAdi { get; set; }
        public string? OdaTurPhotoPath { get; set; }
        public bool? Wifi { get; set; }
        public bool? OdaServisi { get; set; }
        public bool? Balkon { get; set; }
        public bool? Jakuzi { get; set; }
        public bool? Minibar { get; set; }
    }
}
