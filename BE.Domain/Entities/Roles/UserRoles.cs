using BE.Domain.Abstractions;
using BE.Domain.Entities.Users;

namespace BE.Domain.Entities.Roles
{
    public class UserRoles : EntityAuditBase
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
