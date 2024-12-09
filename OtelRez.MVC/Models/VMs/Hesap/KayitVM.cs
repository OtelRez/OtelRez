using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OtelRez.MVC.Models.VMs.Hesap
{
    public class KayitVM
    {
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalıdır")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 2 karakter olmalıdır")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalıdır")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karakter olmalıdır")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karakter olmalidir")]
        [DisplayName("Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
    }
}
