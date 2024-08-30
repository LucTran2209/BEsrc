using BE.Application.Services.Users.UserServiceInputDto;
using BE.Application.Services.Users.UserServiceOutputDto;
using BE.Domain.Entities.Users;

namespace BE.Application.Services.Users
{
    public static class UserExtention
    {
        public static User ToEntity(this CreateUserInputDto command)
        {
            var user = new User();
            user.PhoneNumber = command.PhoneNumber;
            user.UserName = command.UserName;
            user.Email = command.Email;
            user.DateOfBirth = command.DateOfBirth;
            user.Gender = command.Gender;
            user.PasswordHash = command.PasswordHash;
            return user;
        }

        public static GetListUserOutputDto ToDto(this User user)
        {
            return new GetListUserOutputDto
            {
                Id = user.Id,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Role = user.UserRoles.FirstOrDefault(r => !r.IsDeleted).Role?.RoleName ?? string.Empty
            };
        }
    }
}
