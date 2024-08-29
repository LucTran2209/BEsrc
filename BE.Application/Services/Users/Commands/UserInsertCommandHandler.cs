using BE.Application.Services.Users.Commands.Requests;
using BE.Application.Services.Users.Mapping;
using BE.Domain.Abstractions.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Services.Users.Commands
{
    public class UserInsertCommandHandler : IRequestHandler<InsertUserCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserInsertCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();
            user.Id = new Guid();
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.UserRepository.InsertUserRole(user.Id, request.RoleId);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
