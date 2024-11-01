using System.ComponentModel.DataAnnotations;

namespace PetShopDataTransferObjects.Autherezation
{
    public class ResetPasswordByCodeDto
    {
        [RegularExpression("Someone@gmail.com", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "you have to enter new password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "you have to enter the code")]
        public string Code { get; set; }
    }
}
