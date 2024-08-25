using BE.Domain.Abstractions;
using BE.Domain.Abstractions.IEntities;

namespace BE.Domain.Entities.Roles
{
    public class Role : EntityAuditBase, IEntityBase<int>
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string? RoleDescription { get; set; } = null!;
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
