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
    }
}
