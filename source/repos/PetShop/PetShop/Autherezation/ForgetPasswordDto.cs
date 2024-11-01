using System.ComponentModel.DataAnnotations;

namespace PetShopDataTransferObjects.Autherezation
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("Someone@gmail.com", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = string.Empty;
    }
}
