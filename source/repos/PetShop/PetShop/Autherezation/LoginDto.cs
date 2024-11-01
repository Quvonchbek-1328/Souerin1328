using System.ComponentModel.DataAnnotations;

namespace PetShopDataTransferObjects.Autherezation
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("Someone@gmail.com", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [MaxLength(25)] 
        public string Password { get; set; }
    }
}
