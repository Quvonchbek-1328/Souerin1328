using System.ComponentModel.DataAnnotations;
using PetShopDataTransferObjects.Attributes;

namespace PetShopDataTransferObjects.Autherezation
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [AllowedRoles]
        public string Role { get; set; } = string.Empty;
    }
}
