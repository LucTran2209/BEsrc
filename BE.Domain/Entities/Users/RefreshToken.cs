using BE.Domain.Abstractions;

namespace BE.Domain.Entities.Users
{
    public class RefreshToken : EntityAuditBase
    {
        public Guid UserId { get; set; }
        public required string Token { get; set; }
        public DateTime Expires { get; set; }
        public virtual User? User { set; get; }

    }
}
