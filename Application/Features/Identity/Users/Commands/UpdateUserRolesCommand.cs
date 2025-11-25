using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Commands;

public class UpdateUserRolesCommand : IRequest<IResponseWrapper>
{
    public string UserId { get; set; }
    public UserRolesRequest UserRolesRequest { get; set; }
}