using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OtelRez.MVC.Models.VMs.Sayfa
{
    public class AyarlarVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalıdır")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
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

    }
}
