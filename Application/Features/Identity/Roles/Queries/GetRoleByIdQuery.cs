using Application.Wrappers;
using MediatR;

namespace Application.Features.Identity.Roles.Queries;

public class GetRoleByIdQuery : IRequest<IResponseWrapper>
{
    public string RoleId { get; set; }
}