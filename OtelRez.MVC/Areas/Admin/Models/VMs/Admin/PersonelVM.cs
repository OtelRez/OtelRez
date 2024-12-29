using OtelRez.Entity.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace OtelRez.MVC.Areas.Admin.Models.VMs.Admin
{
    public class PersonelVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalıdır")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadı alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter olmalıdır")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public int IzinHakki { get; set; }

        public int? RoleId { get; set; }

        [Required]
        public int PersonelMeslekId { get; set; }

        [Required]
        public int Maas { get; set; }
    }
}
