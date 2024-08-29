using BE.Application.Extensions;
using BE.Application.Models;
using BE.Application.Services.Users.Mapping;
using BE.Application.Services.Users.Queries.Dtos;
using BE.Application.Services.Users.Queries.Requests;
using BE.Domain.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BE.Application.Services.Users.Queries
{
    public class PagedListUserQuery : IRequestHandler<UserPageListRequest, PagedResultModel<UserPageListDto>>
    {
        public readonly IUnitOfWork unitOfWork;
        public PagedListUserQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<PagedResultModel<UserPageListDto>> Handle(UserPageListRequest request, CancellationToken cancellationToken)
        {
            var users = unitOfWork.UserRepository.GetAll();
            var query = users.Filter(request.Search, u => u.UserName.Contains(request.Search));

            var res = await query.OrderBy(request.OrderBy, request.OrderByDesc)
                                .ThenBy(request.ThenBy, request.ThenByDesc)
                                .ToPageList(request)
                                .ToPageResult(await query.CountAsync(), request, u => ModelExtentions.ToDto(u));

            return res;
        }
    }
}
