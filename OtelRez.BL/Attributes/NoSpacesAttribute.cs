using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Attributes
{
    public class NoSpacesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string strValue && strValue.Contains(" "))
            {
                return new ValidationResult("Telefon numarası boşluk içeremez.");
            }
            return ValidationResult.Success;
        }
    }
}
