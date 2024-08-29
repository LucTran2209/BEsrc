using BE.Application.Models;
using BE.Application.Services.Users.Queries.Dtos;
using MediatR;

namespace BE.Application.Services.Users.Queries.Requests
{
    public class UserPageListRequest : PagedResultRequestModel, IRequest<PagedResultModel<UserPageListDto>>
    {
        public string Name {  get; set; } = string.Empty;
    }
}
