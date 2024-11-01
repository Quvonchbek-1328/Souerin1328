using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopDataTransferObjects.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowedRolesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedRoles;

        public AllowedRolesAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && _allowedRoles.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid role specified.");
        }
    }
}
