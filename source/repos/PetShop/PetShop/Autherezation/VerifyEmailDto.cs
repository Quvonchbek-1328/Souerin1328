using System.ComponentModel.DataAnnotations;

namespace PetShopDataTransferObjects.Autherezation
{
    public class VerifyEmailDto
    {
        [RegularExpression("Someone@gmail.com", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
