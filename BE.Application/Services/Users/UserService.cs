using BE.Application.Abstractions;
using BE.Application.Abstractions.ServiceInterfaces;
using BE.Application.Common.Results;
using BE.Application.Extensions;
using BE.Application.Services.Users.UserServiceInputDto;
using BE.Domain.Abstractions.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BE.Application.Services.Users
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<CreateUserInputDto> createUserValidator;

        public UserService(IUnitOfWork unitOfWork, IValidator<CreateUserInputDto> createUserValidator) : base(unitOfWork)
        {
            this.createUserValidator = createUserValidator;
        }

        public async Task<ResultService> CreateAsync(CreateUserInputDto inputDto)
        {
            await createUserValidator.ValidateAndThrowAsync(inputDto);

            var user = inputDto.ToEntity();
            user.Id = new Guid();

            unitOfWork.UserRepository.Insert(user);
            unitOfWork.UserRepository.InsertUserRole(user.Id, inputDto.RoleId);
            await unitOfWork.SaveChangesAsync();

            return new ResultService
            {
                StatusCode = HttpStatusCode.Created.ToString(),
                Message = "Success"
            };
        }

        public async Task<ResultService> GetListUserAsync(GetListUserInputDto inputDto)
        {
            var users = unitOfWork.UserRepository.GetAll();
            var query = users.Filter(inputDto.Search, u => u.UserName.Contains(inputDto.Search));

            var res = await query.OrderBy(inputDto.OrderBy, inputDto.OrderByDesc)
                                    .ThenBy(inputDto.ThenBy, inputDto.ThenByDesc)
                                    .ToPageList(inputDto)
                                    .ToPageResult(await query.CountAsync(), inputDto, u => UserExtention.ToDto(u));

            return new ResultService
            {
                StatusCode = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Datas = res
            };
        }
    }
}
