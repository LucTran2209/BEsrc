using BE.Domain.Abstractions;

namespace BE.Domain.Entities
{
    public class Role : EntityAuditBase<Guid>
    {
        public string RoleName { get; set; } = null!;
        public string RoleDescription { get; set; } = null!;
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
