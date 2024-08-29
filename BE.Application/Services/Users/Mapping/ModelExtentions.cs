using BE.Application.Services.Users.Commands.Requests;
using BE.Application.Services.Users.Queries.Dtos;
using BE.Domain.Entities.Users;

namespace BE.Application.Services.Users.Mapping
{
    public static class ModelExtentions
    {
        public static User ToEntity(this InsertUserCommand command)
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

        public static UserPageListDto ToDto(this User user)
        {
            return new UserPageListDto
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
