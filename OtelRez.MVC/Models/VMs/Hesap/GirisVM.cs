using System.ComponentModel.DataAnnotations;

namespace OtelRez.MVC.Models.VMs
{
    public class GirisVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail adresi girilmesi zorunludur")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre  girilmesi zorunludur")]
        public string Sifre { get; set; }
    }
}
