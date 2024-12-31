using System.ComponentModel.DataAnnotations;

namespace OtelRez.MVC.Models.VMs.Hesap
{
    public class SifremiUnuttumVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
