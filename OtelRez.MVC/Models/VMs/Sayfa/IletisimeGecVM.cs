using System.ComponentModel.DataAnnotations;

namespace OtelRez.MVC.Models.VMs.Sayfa
{
    public class IletisimeGecVM
    {
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        public string Adi { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail adresi girilmesi zorunludur")]
        public string Mail { get; set; }

        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        [Required(ErrorMessage = "Konu girilmesi zorunludur")]
        public string Konu { get; set; }

        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        [Required(ErrorMessage = "Mesaj girilmesi zorunludur")]
        public string Mesaj { get; set; }

    }
}
