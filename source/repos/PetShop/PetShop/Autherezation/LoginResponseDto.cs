using System.ComponentModel.DataAnnotations;
namespace PetShopDataTransferObjects.Autherezation
{
    public class LoginResponseDto
    {
        public LoginResponseDto(Guid id, string token, DateTime expiration,
            string username, string lastname, string email, List<string> roles)
        {
            Id = id;
            Token = token;
            Expiration = expiration;
            Username = username;
            LastName = lastname;
            Email = email;
            Roles = roles;
        }
        public Guid Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string Username { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; }
    }
}