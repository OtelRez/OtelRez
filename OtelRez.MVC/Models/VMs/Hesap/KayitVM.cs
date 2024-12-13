using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OtelRez.BL.Attributes;

namespace OtelRez.MVC.Models.VMs.Hesap
{
    public class KayitVM
    {
        //private string _tel;

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
        [StringLength(11, ErrorMessage = "Telefon numarası 11 karakter olmalıdır")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Telefon numarası sadece 0-9 arasında rakamlardan oluşmalı ve 11 karakter olmalıdır")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Doğum tarihi alanı zorunludur")]
        [DataType(DataType.Date)]
        public DateOnly DogumTarihi { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karakter olmalıdır")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
