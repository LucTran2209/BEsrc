using BE.Domain.Abstractions;
using BE.Domain.Abstractions.IEntities;

namespace BE.Domain.Entities
{
    public class User : EntityBase<Guid>, IDateTracking
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { set; get; }
        public bool IsActive { set; get; }
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? LastModifiedDate { get ; set ; }
        public virtual RefreshToken? refreshToken { set; get; }
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
