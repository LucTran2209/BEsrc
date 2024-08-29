namespace BE.Application.Services.Users.Queries.Dtos
{
    public class UserPageListDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { set; get; }
        public string Role { set; get; } = null!;
    }
}
