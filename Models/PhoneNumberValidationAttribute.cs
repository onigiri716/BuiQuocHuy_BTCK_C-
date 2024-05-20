using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace BuiQuocHuy_BTCK_C_.Models
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        
        {
            var phoneNumber = value as string;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return new ValidationResult("Số điện thoại không được để trống.");
            }

            if (phoneNumber.Length != 10)
            {
                return new ValidationResult("Số điện thoại phải có 10 ký tự.");
            }

            string[] validPrefixes = { "090", "098", "091", "031", "035", "038" };
            if (!validPrefixes.Any(prefix => phoneNumber.StartsWith(prefix)))
            {
                return new ValidationResult("Số điện thoại không hợp lệ!");
            }

            return ValidationResult.Success;
        }
    }
}
