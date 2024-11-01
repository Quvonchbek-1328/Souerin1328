using System.Diagnostics.CodeAnalysis;
using PetShopDataTransferObjects.Roles;
namespace PetShopDataTransferObjects.UserRoles
{
    public class UserRolesDto
    {
        public Guid UserId { get; set; }
        [AllowNull]
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
