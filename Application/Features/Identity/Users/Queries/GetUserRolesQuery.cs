using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Users.Queries;

public class GetUserRolesQuery : IRequest<IResponseWrapper>
{
    public string UserId { get; set; }
}