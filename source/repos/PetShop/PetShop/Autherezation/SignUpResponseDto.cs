namespace PetShopDataTransferObjects.Autherezation
{
    public class SignUpResponseDto
    {
        public SignUpResponseDto(Guid id, string Username,string FirstName, string LastName, List<string> roles)
        {
            Id = id;
            Username = Username;
            FirstName = FirstName;
            LastName = LastName;
            Roles = roles;
        }
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string> Roles { get; set; }
    }
}
