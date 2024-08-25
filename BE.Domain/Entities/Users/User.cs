using BE.Domain.Abstractions;
using BE.Domain.Abstractions.IEntities;
using BE.Domain.Entities.Roles;

namespace BE.Domain.Entities.Users
{
    public class User : EntityAuditBase, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { set; get; }
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
